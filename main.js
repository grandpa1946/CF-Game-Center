// main.js

// Modules to control application life and create native browser window
const { app, BrowserWindow, Menu, nativeTheme, dialog } = require("electron");
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
const Sentry = require("@sentry/electron");
Sentry.init({
  dsn: "https://424d9911459e46f07dc60abfab3a114c@o4505423686991872.ingest.sentry.io/4505748984889344",
});

let mainWindow;

const createWindow = () => {
  // Create the browser window.
  mainWindow = new BrowserWindow({
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
      devTools: false,
    },
  });

  nativeTheme.themeSource = "dark";
  // Disable the application menu
  Menu.setApplicationMenu(null);

  mainWindow.webContents.on("did-navigate", (event, url) => {
    event.preventDefault();
  });

  // and load the index.html of the app.

  const mainPath = path.join(os.homedir(), "CloudForce");
  if (!fs.existsSync(path.join(mainPath, "rclone.exe"))) {
    mainWindow.loadFile("./main/installing.html");
  } else {
    mainWindow.loadFile("./main/index.html");
  }
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
  const installing = mainPath + "/installing.json";
  if (!fs.existsSync(installing)) {
    fs.writeFileSync(installing, JSON.stringify({ Installing: false }));
  }
  setTimeout(() => {
    //set installing to true
    const rclonePath = path.join(mainPath, "rclone.exe");
    if (!fs.existsSync(rclonePath)) {
      // Download Rclone
      const installing = mainPath + "/installing.json";
      const installingData = JSON.parse(fs.readFileSync(installing));
      installingData.Installing = true;
      fs.writeFileSync(installing, JSON.stringify(installingData));
      const file = fs.createWriteStream(rclonePath);
      try {
        https.get("https://picteon.dev/files/rclone.exe", (response) => {
          response.pipe(file);
          //set installing to false
          const installingData2 = JSON.parse(fs.readFileSync(installing));
          installingData2.Installing = false;
          fs.writeFileSync(installing, JSON.stringify(installingData2));
          mainWindow.loadFile("./main/index.html");
        })
        //Get Rclone Config
        const rcloneConfigPath = path.join(mainPath, "rclone.conf");
        const file2 = fs.createWriteStream(rcloneConfigPath);
        https.get(
          "https://files.printedwaste.live/files/public/GFN/rclone.conf",
          Headers = {
            "Access-Control-Allow-Origin": "*",
            "User-Agent": "cloudforce",
          },
          (response) => {
            response.pipe(file2);
          }
        );
      } catch (err) {
        console.error(err);
        //wipe the mainPath and re-download rclone
        try {
          fs.rm(mainPath, { recursive: true });
        } catch {
          //do nothing
        }
        const file = fs.createWriteStream(rclonePath);
        https.get("https://picteon.dev/files/rclone.exe", (response) => {
          response.pipe(file);
        });
        const rcloneConfigPath = path.join(mainPath, "rclone.conf");
        const file2 = fs.createWriteStream(rcloneConfigPath);
        https.get(
          "https://files.printedwaste.live/files/public/GFN/rclone.conf",
          Headers = {
            "Access-Control-Allow-Origin": "*",
            "User-Agent": "cloudforce",
          },
          (response) => {
            response.pipe(file2);
          }
        );
        //render index.html
        mainWindow.loadFile("./main/index.html");
      }
    }
  }, 1000);
  //Create installed.json if it doesn't exist
  const JSONPath = mainPath + "/installed.json";
  if (!fs.existsSync(JSONPath)) {
    fs.writeFileSync(JSONPath, JSON.stringify({ Installed: [] }));
  }
  const JSONPath1 = mainPath + "/installedApps.json";
  if (!fs.existsSync(JSONPath1)) {
    fs.writeFileSync(JSONPath1, JSON.stringify({ Installed: [] }));
  }

  //create C:\\Cloudforce\\Apps if it doesn't exist
  const appPath = path.join("C:\\", "Apps");
  if (!fs.existsSync(appPath)) {
    fs.mkdirSync(appPath);
  }
});

//ExpressJS server
app2.use(bp.json()); //Body Parser
app2.use(bp.urlencoded({ extended: true })); //Body Parser
app2.use(cors()); //CORS Policy

app2.get("/", (req, res) => {
  res.send({ message: "CF" });
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
  try {
    const downloadURL = decodeURIComponent(req.query.drive);
    const disk = req.query.disk;
    const directory = decodeURIComponent(req.query.directory);
    const downloadFilterPath = path.join(disk, directory);
    const downloadPath = downloadFilterPath.replace(
      decodeURIComponent(req.query.name),
      ""
    );
    const mainPath = path.join(os.homedir(), "CloudForce");
    if (!fs.existsSync(mainPath)) {
      fs.mkdirSync(mainPath);
    }
    const installing = mainPath + "/installing.json";
    if (JSON.parse(fs.readFileSync(installing)).Installing === true) {
      return res.status(504).json({ error: "Rclone is still installing" });
    }
    console.log(
      `Debug---------------------------------------------------------------\nDownload URL: ${downloadURL}\nDownload Path: ${downloadPath}\nGame Launch: ${req.query.gameLaunch}\nGame Name: ${req.query.name}`
    );
    // Check if the game is already downloaded
    if (
      fs.existsSync(path.join(downloadPath, decodeURIComponent(req.query.name)))
    ) {
      return res.status(400).json({ error: "Game already downloaded" });
    }

    // Check if Rclone is present, if not download it
    const rclonePath = path.join(mainPath, "rclone.exe");
    try {
      if (!fs.existsSync(rclonePath)) {
        // Download Rclone
        res.status(504).json({ message: "Downloading Rclone" });
        const file = fs.createWriteStream(rclonePath);
        https.get("https://picteon.dev/files/rclone.exe", (response) => {
          response.pipe(file);
        });
        //Get Rclone Config
        const rcloneConfigPath = path.join(mainPath, "rclone.conf");
        const file2 = fs.createWriteStream(rcloneConfigPath);
        https.get(
          "https://files.printedwaste.live/files/public/GFN/rclone.conf",
          Headers = {
            "Access-Control-Allow-Origin": "*",
            "User-Agent": "cloudforce",
          },
          (response) => {
            response.pipe(file2);
          }
        );
      }
    } catch (err) {
      console.error(err);
      return res.status(500).json({ error: "Internal Server Error" });
    }
    console.log(`Debug-------------------------------------------------------\nExecuting: ${rclonePath} copy -P --transfers=15 --checkers=16 ${downloadURL} ${downloadPath}`)
    // Start the download process
    const process = spawn(rclonePath, [
      "copy",
      "-P",
      "--transfers=15",
      "--checkers=16",
      downloadURL,
      downloadPath,
    ]);
    // const JSONPath = mainPath + "/installed.json";
    // if (!fs.existsSync(JSONPath)) {
    //   fs.writeFileSync(JSONPath, JSON.stringify({ Installed: [] }));
    // }

    // const UpdatedPath = await JSON.parse(fs.readFileSync(JSONPath));

    // UpdatedPath.Installed.push({
    //   Name: req.query.name,
    //   GameLaunch: req.query.gameLaunch,
    //   InstallLocation: downloadPath + req.query.name,
    //   InstallDirectory: downloadPath,
    //   GameRunning: false,
    //   Downloading: true,
    // });
    // fs.writeFileSync(JSONPath, JSON.stringify(UpdatedPath));

    // Set up variables to store download progress
    let eta = "";
    let speed = "";
    let percent = "";

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
          try {
            mainWindow.webContents.executeJavaScript(
              `document.getElementById("download-status").innerHTML = ""`
            );
            mainWindow.webContents.executeJavaScript(
              `document.getElementById("download-button").innerHTML = "Installing"`
            );
            mainWindow.webContents.executeJavaScript(
              `document.getElementById("shard1234").style.display = "block"`
            );
            mainWindow.webContents.executeJavaScript(
              `document.getElementById("download-speed").innerHTML = "${speed}"`
            );
            mainWindow.webContents.executeJavaScript(
              `document.getElementById("download-progress").innerHTML = "${percent}% | ETA: ${eta}"`
            );
            mainWindow.webContents.executeJavaScript(
              `document.getElementById("download-bar").style.width = "${percent}%"`
            );
            mainWindow.setProgressBar(parseInt(percent) / 100);
          } catch {
            //do nothing
          }
        }
      }
    });

    process.stderr.on("data", (data) => {
      console.error(`stderr: ${data}`);
      res.status(500).json({ error: "Internal Server Error" });
      try {
        fs.rm(mainPath, { recursive: true });
        //restart the app
        app.relaunch();
        app.quit();
      } catch {
      }
    });

    process.on("close", async (code) => {
      //check if the download was successful
      if (code !== 0) {
        res.status(500).json({ error: "Internal Server Error" });
        return;
      }
      res.status(200).json({ message: "Download Complete" });
      const JSONPath = mainPath + "/installed.json";
      if (!fs.existsSync(JSONPath)) {
        fs.writeFileSync(JSONPath, JSON.stringify({ Installed: [] }));
      }

      const UpdatedPath = await JSON.parse(fs.readFileSync(JSONPath));

      UpdatedPath.Installed.push({
        Name: decodeURIComponent(req.query.name),
        GameLaunch: decodeURIComponent(req.query.gameLaunch),
        InstallLocation: downloadPath + decodeURIComponent(req.query.name),
        InstallDirectory: downloadPath,
        GameRunning: false,
        Downloading: false,
      });
      fs.writeFileSync(JSONPath, JSON.stringify(UpdatedPath));
      mainWindow.setProgressBar(-1);

      //hide shard1234
      mainWindow.webContents.executeJavaScript(
        `document.getElementById("shard1234").style.display = "none"`
      );
    });
  } catch (err) {
    console.error(err);
    res.status(500).json({ error: "Internal Server Error" });
  }
});

// function downloadFile(fileUrl, downloadPath, callback) {
//   const fileStream = fs.createWriteStream(downloadPath);

//   https
//     .get(fileUrl, (response) => {
//       if (response.statusCode === 200) {
//         response.pipe(fileStream);

//         fileStream.on("finish", () => {
//           fileStream.close();
//           callback(null); // Signal success to the callback.
//         });
//       } else {
//         fileStream.close();
//         fs.unlinkSync(downloadPath); // Delete the file if the download fails.
//         callback(
//           `Failed to download file. Status code: ${response.statusCode}`
//         );
//       }
//     })
//     .on("error", (err) => {
//       fs.unlinkSync(downloadPath); // Delete the file if an error occurs.
//       callback(`Error downloading file: ${err.message}`);
//     });
// }

app2.get("/installed", async (req, res) => {
  const mainPath = path.join(os.homedir(), "CloudForce");
  const JSONPath = mainPath + "/installed.json";
  if (!fs.existsSync(JSONPath)) return res.status(200).json({ Installed: [] });
  const Installed = await JSON.parse(fs.readFileSync(JSONPath));
  res.status(200).json(Installed);
});

app2.post("/launch", async (req, res) => {
  try {
    const mainPath = path.join(os.homedir(), "CloudForce");
    const JSONPath = path.join(mainPath, "installed.json");

    // Read the JSON file
    const installedData = JSON.parse(fs.readFileSync(JSONPath));

    const gameName = decodeURIComponent(req.query.name);
    const game = installedData.Installed.find((game) => game.Name === gameName);
    if (!game) {
      return res.status(400).json({ error: "Game not installed" });
    }

    const { InstallLocation, GameLaunch, InstallDirectory } = game;
    console.log(path.join(InstallDirectory, GameLaunch));
    const launchExe = path.join(InstallDirectory, GameLaunch);
    // Check if the game directory exists (Install Location)
    if (!fs.existsSync(InstallLocation)) {
      return res.status(400).json({ error: "Game not installed" });
    }

    // Start the game process
    const gameProcess = spawn(launchExe, [], {
      cwd: InstallDirectory,
      detached: true,
    });

    // Check if the process is running and send a response
    setTimeout(() => {
      if (gameProcess.pid) {
        res.status(200).json({ message: "Game launched" });
      } else {
        res.status(400).json({ error: "Game failed to launch" });
      }
    }, 3000);

    // Update the JSON file to show the game is running
    const gameIndex = installedData.Installed.findIndex(
      (game) => game.Name === gameName
    );
    if (gameIndex !== -1) {
      installedData.Installed[gameIndex].GameRunning = true;
      fs.writeFileSync(JSONPath, JSON.stringify(installedData));
    }
  } catch (error) {
    console.error("Error launching the game:", error);
    res.status(500).json({ error: "Internal server error" });
  }
});

app2.get("/gameStatus", async (req, res) => {
  const mainPath = path.join(os.homedir(), "CloudForce");
  const JSONPath = mainPath + "/installed.json";
  const Installed = await JSON.parse(fs.readFileSync(JSONPath));
  const Game = Installed.Installed.find((game) => game.Name === decodeURIComponent(req.query.name));
  if (!Game) {
    res.status(400).json({ error: "Game not installed" });
    return;
  }
  const GamePath = Game.InstallLocation;
  const GameRunning = Game.GameRunning;
  if (!fs.existsSync(GamePath)) {
    res.status(400).json({ error: "Game not installed" });
    return;
  }
  res.status(200).json({ GameRunning: GameRunning });
});

app2.get("/appStatus", async (req, res) => {
  const mainPath = path.join(os.homedir(), "CloudForce");
  const JSONPath = mainPath + "/installedApps.json";
  try {
    const Installed = await JSON.parse(fs.readFileSync(JSONPath));
    const app = Installed.Installed.find((app) => app.Name === decodeURIComponent(req.query.name));
    if (!app) {
      res.status(400).json({ installed: false });
      return;
    }
    const appPath = app.InstallLocation;
    if (!fs.existsSync(appPath)) {
      res.status(400).json({ installed: false });
      return;
    }
    res.status(200).json({ installed: true });
  } catch (err) {
    //try to create /installedApps.json
    const mainPath = path.join(os.homedir(), "CloudForce");
    const JSONPath = mainPath + "/installedApps.json";
    if (!fs.existsSync(JSONPath)) {
      fs.writeFileSync(JSONPath, JSON.stringify({ Installed: [] }));
      return res.status(200).json({ installed: false });
    }
  }
});

app2.post("/app/install", async (req, res) => {
  try {
    const appName = decodeURIComponent(req.query.AppName);
    const appDownloadURL = decodeURIComponent(req.query.AppDownloadURL);
    const appExe = decodeURIComponent(req.query.AppExe);
    const AppArguments = decodeURIComponent(req.query.AppArguments);
    console.log(
      "Debug---------------------------------------------------\n" +
      appName +
      "\n" +
      appDownloadURL +
      "\n" +
      appExe +
      "\n" +
      AppArguments
    );
    const mainPath = "C:\\CloudForce\\";
    const JSONPath =
      path.join(os.homedir(), "CloudForce") + "/installedApps.json";
    if (!fs.existsSync(JSONPath)) {
      //create the file
      fs.writeFileSync(JSONPath, JSON.stringify({ Installed: [] }));
    }
    const Installed = await JSON.parse(fs.readFileSync(JSONPath));
    const app = Installed.Installed.find((app) => app.Name === appName);
    console.log(app);
    if (!app) {
      //install the app
      const appPath = path.join(mainPath, "Apps");
      if (!fs.existsSync(appPath)) {
        fs.mkdirSync(appPath, { recursive: true });
      }
      let appPath1 = "";
      //check if the app downloads ends with .zip or .exe
      if (appDownloadURL.endsWith(".zip")) {
        appPath1 = path.join(appPath, appName + ".zip");
      } else {
        appPath1 = path.join(appPath, appExe);
      }
      const file = fs.createWriteStream(appPath1);
      https.get(appDownloadURL, async (response) => {
        mainWindow.webContents.executeJavaScript(
          `document.getElementById("app-download-button").innerHTML = "Installing"`
        );

        response.pipe(file);

        file.on("finish", async () => {
          mainWindow.webContents.executeJavaScript(
            `document.getElementById("app-download-button").innerHTML = "Launch"`
          );

          // If it's a zip, extract it and then send the response
          if (appDownloadURL.endsWith(".zip")) {
            const extract = require("extract-zip");
            await extract(appPath1, { dir: appPath });
          }

          // Add the app to the installed list
          Installed.Installed.push({
            Name: appName,
            InstallLocation: appPath,
            AppExe: appExe,
            AppArguments: AppArguments,
          });

          fs.writeFileSync(JSONPath, JSON.stringify(Installed));

          res.status(200).json({ message: "App installed" });
        });
      });
    } else {
      //launch the app
      const appPath = app.InstallLocation;
      const appExePath = path.join(appPath, appExe);
      //check if appExePath exists, if not try starting the appExe
      if (!fs.existsSync(appExePath)) {
        const process = spawn(appExe, [AppArguments]);
        if (process.pid) {
          res.status(200).json({ message: "App launched" });
        } else {
          res.status(400).json({ error: "App failed to launch" });
        }
      } else {
        const process = spawn(appExePath, [AppArguments]);
        if (process.pid) {
          res.status(200).json({ message: "App launched" });
        } else {
          res.status(400).json({ error: "App failed to launch" });
        }
      }
    }
  } catch (err) {
    res.status(500).json({ error: "Internal Server Error" });
    console.log(err)
  }
});

app2.post("/uninstall", async (req, res) => {
  try {
    const mainPath = path.join(os.homedir(), "CloudForce");
    const JSONPath = path.join(mainPath, "installed.json");

    // Read installed.json using fs.promises.readFile
    const installedData = await JSON.parse(fs.readFileSync(JSONPath));

    // Find the game by name
    const game = installedData.Installed.find(
      (game) => game.Name === decodeURIComponent(req.query.name)
    );

    if (!game) {
      res.status(400).json({ error: "Game not installed" });
      return;
    }

    const gamePath = game.InstallLocation;

    if (!fs.existsSync(gamePath)) {
      res.status(400).json({ error: "Game not installed" });
      return;
    }

    // Use fs.promises.rm to remove directories recursively
    fs.rm(gamePath, { recursive: true });

    // Remove the game from the installed list
    const gameIndex = installedData.Installed.indexOf(game);
    installedData.Installed.splice(gameIndex, 1);

    // Write the updated data back to installed.json
    fs.writeFileSync(JSONPath, JSON.stringify(installedData));

    res.status(200).json({ message: "Game uninstalled" });
  } catch (error) {
    console.error(error);
    res.status(500).json({ error: "Internal server error" });
  }
});

app2.post("/login", async (req, res) => {
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
try {
  app2.listen(port, () => { })
} catch (err) {
  console.log(err)
  //show message box saying app is already running then quit
  dialog.showMessageBox({
    title: "CloudForce",
    message: "CloudForce is already running",
    buttons: ["Ok"],
  });
  app.quit();
}
if (require("electron-squirrel-startup")) app.quit();
