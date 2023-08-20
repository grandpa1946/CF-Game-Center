// main.js

// Modules to control application life and create native browser window
const { app, BrowserWindow, Menu } = require("electron");
const path = require("path");
const fs = require("fs");
const os = require("os");
const { exec, spawn } = require("child_process");
const express = require("express");
const app2 = express();
const bp = require("body-parser"); //Body Parser
const cors = require("cors"); //CORS Policy
const https = require("https");
const KeyAuth = require("./KeyAuth");
const { env } = require("process");

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
      devTools: true,
    },
  });
  // Disable the application menu
  Menu.setApplicationMenu(null);

  mainWindow.webContents.on("did-navigate", (event, url) => {
    event.preventDefault();
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
      "https://files.zortos.me/files/public/CF%20GC%20Resources/rclone.conf",
      (response) => {
        response.pipe(file2);
      }
    );
  }

  //Create installed.json if it doesn't exist
  const JSONPath = mainPath + "/installed.json";
  if (!fs.existsSync(JSONPath)) {
    fs.writeFileSync(JSONPath, JSON.stringify({ Installed: [] }));
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
  const disk = req.query.disk;
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
  console.log(downloadPath);
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
      "https://files.zortos.me/files/public/CF%20GC%20Resources/rclone.conf",
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
    res.status(200).json({ message: "Download Complete" });
    res.end();
    const JSONPath = mainPath + "/installed.json";
    if (!fs.existsSync(JSONPath)) {
      fs.writeFileSync(JSONPath, JSON.stringify({ Installed: [] }));
    }

    const UpdatedPath = await JSON.parse(fs.readFileSync(JSONPath));

    await UpdatedPath.Installed.push({
      Name: req.query.name,
      GameLaunch: req.query.gameLaunch,
      InstallLocation: downloadPath + req.query.name,
      InstallDirectory: downloadPath,
      GameRunning: false,
    });
    fs.writeFileSync(JSONPath, JSON.stringify(UpdatedPath));
  });
});

app2.get("/installed", async (req, res) => {
  const mainPath = path.join(os.homedir(), "CloudForce");
  const JSONPath = mainPath + "/installed.json";
  if (!fs.existsSync(JSONPath)) return res.status(200).json({ Installed: [] });
  const Installed = await JSON.parse(fs.readFileSync(JSONPath));
  res.status(200).json(Installed);
});

app2.post("/launch", async (req, res) => {
  const mainPath = path.join(os.homedir(), "CloudForce");
  const JSONPath = mainPath + "/installed.json";
  const Installed = await JSON.parse(fs.readFileSync(JSONPath));
  const Game = Installed.Installed.find((game) => game.Name === req.query.name);
  const GamePath = Game.InstallLocation;
  const GameLaunch = Game.GameLaunch;
  const GameDirectory = Game.InstallDirectory;
  const LaunchExe = path.join(GameDirectory, GameLaunch);
  // Check if the game directory exists (Install Location)
  if (!fs.existsSync(GamePath)) {
    res.status(400).json({ error: "Game not installed" });
    return;
  }
  //Start the game process
  const process = spawn(LaunchExe, [], {
    cwd: GameDirectory,
    detached: true,
  });
  process.unref();
  //Check if the process is running and send a response
  if (process.pid) {
    res.status(200).json({ message: "Game Launched" });
  } else {
    res.status(400).json({ error: "Game failed to launch" });
  }

  //Update the JSON file to show the game is running
  const mathPath = mainPath + "/installed.json";
  const UpdatedPath = await JSON.parse(fs.readFileSync(mathPath));
  const GameIndex = UpdatedPath.Installed.findIndex(
    (game) => game.Name === req.query.name
  );
  UpdatedPath.Installed[GameIndex].GameRunning = true;

  //Write the updated JSON file
  fs.writeFileSync(mathPath, JSON.stringify(UpdatedPath));

  //When game is closed, update the JSON file to show the game is not running
  process.on("close", async (code) => {
    const mathPath = mainPath + "/installed.json";
    const UpdatedPath = await JSON.parse(fs.readFileSync(mathPath));
    const GameIndex = UpdatedPath.Installed.findIndex(
      (game) => game.Name === req.query.name
    );
    UpdatedPath.Installed[GameIndex].GameRunning = false;
    fs.writeFileSync(mathPath, JSON.stringify(UpdatedPath));
  });
});

app2.get("/gameStatus", async (req, res) => {
  const mainPath = path.join(os.homedir(), "CloudForce");
  const JSONPath = mainPath + "/installed.json";
  const Installed = await JSON.parse(fs.readFileSync(JSONPath));
  const Game = Installed.Installed.find((game) => game.Name === req.query.name);
  const GamePath = Game.InstallLocation;
  const GameRunning = Game.GameRunning;
  if (!fs.existsSync(GamePath)) {
    res.status(400).json({ error: "Game not installed" });
    return;
  }
  res.status(200).json({ GameRunning: GameRunning });
});

app2.get("/uninstall", async (req, res) => {
  const mainPath = path.join(os.homedir(), "CloudForce");
  const JSONPath = mainPath + "/installed.json";
  const Installed = await JSON.parse(fs.readFileSync(JSONPath));
  const Game = Installed.Installed.find((game) => game.Name === req.query.name);
  const GamePath = Game.InstallLocation;
  const GameDirectory = Game.InstallDirectory;
  if (!fs.existsSync(GamePath)) {
    res.status(400).json({ error: "Game not installed" });
    return;
  }
  fs.rmdirSync(GameDirectory, { recursive: true });

  const mathPath = mainPath + "/installed.json";
  const UpdatedPath = await JSON.parse(fs.readFileSync(mathPath));
  const GameIndex = UpdatedPath.Installed.findIndex(
    (game) => game.Name === req.query.name
  );
  UpdatedPath.Installed.splice(GameIndex, 1);

  fs.writeFileSync(mathPath, JSON.stringify(UpdatedPath));

  res.status(200).json({ message: "Game uninstalled" });
});

app2.get("/login", async (req, res) => {
  const KeyAuthApp = new KeyAuth(
    "CF Game Center", // Application Name
    "0t0Sr0pLaB", // OwnerID
    env.LOGINSECRET, // Application Secret
    "1.0" // Application Version
  );
  const KeyAuth = await KeyAuthApp.init();
  const Login = await KeyAuth.login(req.query.username, req.query.password);
  if (Login.status === "success") {
    res.status(200).json({ message: "Login Successful" });
  } else {
    res.status(400).json({ error: "Login Failed" });
  }
});

app2.get("/savetocloud", async (req, res) => {
  //Get the game name from the query
  const GameName = req.query.name;
  //Get the game local save directory from the query
  const GameSaveDirectory = req.query.saveDirectory;
  //Get the game cloud save directory from the query
  const GameCloudDirectory = req.query.cloudDirectory;
  //use rclone to save it to cloud
  const process = spawn(rclonePath, [
    "copy",
    GameSaveDirectory,
    GameCloudDirectory,
  ]);
  //Check if the process is running and no errors outputted
  if (process.pid) {
    res.status(200).json({ message: "Save Successful" });
  } else {
    res.status(400).json({ error: "Save Failed" });
  }
});

app2.get("/loadfromcloud", async (req, res) => {
  //Get the game name from the query
  const GameName = req.query.name;
  //Get the game local save directory from the query
  const GameSaveDirectory = req.query.saveDirectory;
  //Get the game cloud save directory from the query
  const GameCloudDirectory = req.query.cloudDirectory;
  //use rclone to save it to cloud
  const process = spawn(rclonePath, [
    "copy",
    GameCloudDirectory,
    GameSaveDirectory,
  ]);
  //Check if the process is running and no errors outputted
  if (process.pid) {
    res.status(200).json({ message: "Load Successful" });
  } else {
    res.status(400).json({ error: "Load Failed" });
  }
});
const port = 3000;
app2.listen(port, () => {});
if (require("electron-squirrel-startup")) app.quit();
