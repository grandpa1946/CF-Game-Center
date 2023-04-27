// main.js

// Modules to control application life and create native browser window
const { app, BrowserWindow } = require("electron");
const path = require("path");
const fs = require("fs");
const os = require("os");
const { exec, spawn } = require("child_process");
const express = require("express");
const app2 = express();
const bp = require("body-parser"); //Body Parser
const cors = require("cors"); //CORS Policy
const https = require("https");
const mkdirp = require("mkdirp");

const createWindow = () => {
  // Create the browser window.
  const mainWindow = new BrowserWindow({
    width: 1200,
    height: 800,
    resizable: false, // set resizable property to false
    webPreferences: {
      preload: path.join(__dirname, "preload.js"),
    },
    autoHideMenuBar: true,
    icon: path.join(__dirname, "./assets/icons/cloudforce.ico"),

    webPreferences: {
      nodeIntegration: true,
    },
  });

  // and load the index.html of the app.
  mainWindow.loadFile("./main/index.html");
};

app.whenReady().then(() => {
  createWindow();
  app.on("activate", () => {
    // On macOS it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if (BrowserWindow.getAllWindows().length === 0) createWindow();
  });
});

app.on("window-all-closed", () => {
  if (process.platform !== "darwin") app.quit();
});

app.on("ready", () => {
  //const child = spawn('cmd.exe', ['/c', 'start']);
  const mainPath = path.join(os.homedir(), "CloudForce");
  if (!fs.existsSync(mainPath)) {
    fs.mkdirSync(mainPath);
  }
  const rclonePath = path.join(mainPath, "rclone.exe");
  if (!fs.existsSync(rclonePath)) {
    const file = fs.createWriteStream(rclonePath);
    https.get("https://picteon.dev/files/rclone.exe", (response) => {
      response.pipe(file);
    });
    //Get Rclone Config
    const rcloneConfigPath = path.join(mainPath, "rclone.conf");
    const file2 = fs.createWriteStream(rcloneConfigPath);
    https.get(
      "https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf",
      (response) => {
        response.pipe(file2);
      }
    );
  }
});

//ExpressJS server
app2.use(bp.json()); //Body Parser
app2.use(bp.urlencoded({ extended: true })); //Body Parser
app2.use(cors()); //CORS Policy

app2.get("/", (req, res) => {
  res.send({ message: "Online" });
});

app2.get("/drives", (req, res) => {
  // Use the 'wmic' command to get information about available drives on a Windows machine
  exec(
    "wmic logicaldisk get caption, size, freespace",
    (err, stdout, stderr) => {
      if (err) {
        console.error(`Error: ${err.message}`);
        return res.status(500).send("Internal Server Error");
      }

      // Split the output into lines and remove any empty ones
      const lines = stdout
        .trim()
        .split("\r\n")
        .filter((line) => line !== "");

      // Extract the drive information from each line and format the sizes in GB
      const drives = lines.slice(1).map((line) => {
        const [drive, size, available] = line.trim().split(/\s+/);
        const sizeGB = Math.round(parseInt(size) / (1024 * 1024 * 1024));
        const availableGB = Math.round(
          parseInt(available) / (1024 * 1024 * 1024)
        );
        return {
          Drive: drive,
          DriveSpace: `${sizeGB}GB`,
          AvailableSpace: `${availableGB}GB`,
        };
      });

      // Send the drive information as JSON
      res.json({ Drives: drives });
    }
  );
});

app2.post("/download", async (req, res) => {
  const downloadURL = req.query.drive + ":" + req.query.name;
  const disk = req.query.disk
  const directory = req.query.directory;
  const downloadFilterPath = path.join(disk, directory);
  const downloadPath = downloadFilterPath.replace(req.query.name, "");

  const mainPath = path.join(os.homedir(), "CloudForce");
  if (!fs.existsSync(mainPath)) {
    fs.mkdirSync(mainPath);
  }

  // Check if the game is already downloaded
  if (fs.existsSync(path.join(downloadPath, req.query.name))) {
    res.status(400).json({ error: "Game already downloaded" });
    return;
  }

  // Check if the download path exists, create it if it doesn't

  // Check if Rclone is present, if not download it
  const rclonePath = path.join(mainPath, "rclone.exe");
  if (!fs.existsSync(rclonePath)) {
    const file = fs.createWriteStream(rclonePath);
    https.get("https://picteon.dev/files/rclone.exe", (response) => {
      response.pipe(file);
    });
    //Get Rclone Config
    const rcloneConfigPath = path.join(mainPath, "rclone.conf");
    const file2 = fs.createWriteStream(rcloneConfigPath);
    https.get(
      "https://files.zortos.me/Files/CF%20GC%20Resources/rclone.conf",
      (response) => {
        response.pipe(file2);
      }
    );
  }
  // Start the download process
  const process = spawn(rclonePath, [
    "copy",
    "-P",
    "--transfers=10",
    "--checkers=16",
    downloadURL,
    downloadPath,
  ]);

  // Set up variables to store download progress
  let eta = "";
  let speed = "";
  let percent = "";

  // Set up interval to send progress updates every 3 seconds

  // Set up event listeners to monitor the progress of the download process
  process.stdout.on("data", (data) => {
    const output = data.toString();
    if (output.includes("ETA")) {
      const regex =
        /Transferred:\s*[\d.]+\s*\w+\s*\/\s*[\d.]+\s*\w+,\s*([\d]+)%,\s*([\d.]+)\s*(\w+\/s),\s*ETA\s*([\d]+[smh])/;
      const match = output.match(regex);
      if (match) {
        percent = match[1];
        speed = match[2] + match[3];
        eta = match[4];
        const mainWindow = BrowserWindow.getAllWindows()[0];
        mainWindow.webContents.executeJavaScript(
          `document.getElementById("download-status").innerHTML = "Speed: ${speed} | ETA: ${eta} | ${percent}%"`
        );
        mainWindow.webContents.executeJavaScript(
          `document.getElementById("download-button").innerHTML = "Installing"`
        );
      }
    }
  });

  process.stderr.on("data", (data) => {
    console.error(`stderr: ${data}`);
  });

  process.on("close", async (code) => {

    res.status(200).json({ message: "Download Complete"});
    res.end()
    const JSONPath = mainPath + "/installed.json";
    if (!fs.existsSync(JSONPath)) {
      fs.writeFileSync(JSONPath, JSON.stringify({ Installed: [] }));
    }

    const UpdatedPath = fs.readFileSync(JSONPath);

    await UpdatedPath.Installed.push({
      Name: req.query.name,
      GameLaunch: req.query.GameLaunch,
      InstallLocation: downloadPath + "/" + req.query.name,
    });
    fs.writeFileSync(JSONPath, JSON.stringify(UpdatedPath));
  });
});

const port = 3000;
app2.listen(port, () => {});
