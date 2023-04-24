// main.js


// Modules to control application life and create native browser window
const { app, BrowserWindow } = require('electron')
const path = require('path')
const { spawn } = require('child_process');
const express = require('express');
const app2 = express();
const bp = require("body-parser"); //Body Parser
const cors = require("cors"); //CORS Policy


const createWindow = () => {
  // Create the browser window.
  const mainWindow = new BrowserWindow({
    width: 1200,
    height: 800,
    resizable: false, // set resizable property to false
    webPreferences: {
      preload: path.join(__dirname, 'preload.js')
    },
    autoHideMenuBar: true,
    icon: path.join(__dirname, './assets/icons/cloudforce.ico'),
    
    webPreferences: {
      nodeIntegration: true,
    },
  })

  // and load the index.html of the app.
  mainWindow.loadFile('./main/index.html')


}


app.whenReady().then(() => {
  createWindow()
  app.on('activate', () => {
    // On macOS it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if (BrowserWindow.getAllWindows().length === 0) createWindow()
  })
})


app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') app.quit()
})

app.on('ready', () => {
  //const child = spawn('cmd.exe', ['/c', 'start']);
  
});



//ExpressJS server
app2.use(bp.json()); //Body Parser
app2.use(bp.urlencoded({ extended: true })); //Body Parser
app2.use(cors()); //CORS Policy



app2.get('/', (req, res) => {
  res.send({ message: 'Online' })
})


app2.get('/drives', (req, res) => {
  // Use the 'wmic' command to get information about available drives on a Windows machine
  exec('wmic logicaldisk get caption, size, freespace', (err, stdout, stderr) => {
    if (err) {
      console.error(`Error: ${err.message}`);
      return res.status(500).send('Internal Server Error');
    }

    // Split the output into lines and remove any empty ones
    const lines = stdout.trim().split('\r\n').filter((line) => line !== '');

    // Extract the drive information from each line
    const drives = lines.slice(1).map((line) => {
      const [drive, size, available] = line.trim().split(/\s+/);
      return { Drive: drive, DriveSpace: size, AvailableSpace: available };
    });

    // Send the drive information as JSON
    res.json({ Drives: drives });
  });
});




const port = 3000
app2.listen(port, () => {})
