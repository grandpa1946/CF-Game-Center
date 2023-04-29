console.log("Loaded");

let sidebar = document.querySelector(".sidebar");
let closeBtn = document.querySelector("#btn");
let searchBtn = document.querySelector(".bx-search");
const downloadURL = "localhost:3000";

//Floating pop-up
const popupBox = document.querySelector(".floating-popup-box");
const closeButton = document.querySelector(".floating-popup-box-close-button");

function showPopupBox(message, emoji, delay) {
  popupBox.querySelector("p").textContent = message;
  if (emoji) {
    document.getElementById("Popup-Emoji").textContent = emoji;
  }
  popupBox.classList.add("show");
  if (delay) {
    setTimeout(function () {
      popupBox.classList.add("hide");
      setTimeout(function () {
        popupBox.classList.remove("show");
        popupBox.classList.remove("hide");
      }, 500);
    }, delay);
  }
}

closeButton.addEventListener("click", function () {
  popupBox.classList.add("hide");
  setTimeout(function () {
    popupBox.classList.remove("show");
    popupBox.classList.remove("hide");
  }, 500); // Change delay time as needed
});

closeBtn.addEventListener("click", () => {
  sidebar.classList.toggle("open");
  menuBtnChange();
});

searchBtn.addEventListener("click", () => {
  sidebar.classList.toggle("open");
  menuBtnChange();
});

function menuBtnChange() {
  if (sidebar.classList.contains("open")) {
    closeBtn.classList.replace("bx-menu", "bx-menu-alt-right");
  } else {
    closeBtn.classList.replace("bx-menu-alt-right", "bx-menu");
  }
}

function showDashboardSection() {
  let homeSection = document.querySelector("#dashboard-section");
  let filesSection = document.querySelector("#files-section");
  let settingsSection = document.querySelector("#settings-section");
  let downloadSection = document.querySelector("#downloader-section");
  let installedSection = document.querySelector("#installed-section");

  homeSection.style.display = "block";
  filesSection.style.display = "none";
  settingsSection.style.display = "none";
  downloadSection.style.display = "none";
  installedSection.style.display = "none";
}

function showSettingsSection() {
  let homeSection = document.querySelector("#dashboard-section");
  let filesSection = document.querySelector("#files-section");
  let settingsSection = document.querySelector("#settings-section");
  let downloadSection = document.querySelector("#downloader-section");
  let installedSection = document.querySelector("#installed-section");

  homeSection.style.display = "none";
  filesSection.style.display = "none";
  settingsSection.style.display = "block";
  downloadSection.style.display = "none";
  installedSection.style.display = "none";
}

function showFilesSection() {
  let homeSection = document.querySelector("#dashboard-section");
  let filesSection = document.querySelector("#files-section");
  let settingsSection = document.querySelector("#settings-section");
  let downloadSection = document.querySelector("#downloader-section");
  let installedSection = document.querySelector("#installed-section");

  homeSection.style.display = "none";
  filesSection.style.display = "block";
  settingsSection.style.display = "none";
  downloadSection.style.display = "none";
  installedSection.style.display = "none";
}

function showDownloadSection() {
  let homeSection = document.querySelector("#dashboard-section");
  let filesSection = document.querySelector("#files-section");
  let settingsSection = document.querySelector("#settings-section");
  let downloadSection = document.querySelector("#downloader-section");
  let installedSection = document.querySelector("#installed-section");
  fetchInstalledContent();
  homeSection.style.display = "none";
  filesSection.style.display = "none";
  settingsSection.style.display = "none";
  downloadSection.style.display = "none";
  installedSection.style.display = "block";
}

function fetchInstalledContent() {
  const bannerList = document.getElementById("banner-list");
  //clear it
  bannerList.innerHTML = "";
  fetch("http://localhost:3000/installed")
    .then((response) => response.json())
    .then((data) => {
      data.Installed.forEach((banner) => {
        const bannerItem = document.createElement("div");
        bannerItem.className = "banner-item";

        const bannerName = document.createElement("div");
        bannerName.className = "banner-name";
        bannerName.textContent = banner.Name;

        const bannerButtons = document.createElement("div");
        bannerButtons.className = "banner-buttons";

        const infoButton = document.createElement("button");
        infoButton.innerHTML = '<i class="bx bx-trash"></i>';
        infoButton.classList.add("info-button");

        const playButton = document.createElement("button");
        playButton.innerHTML = '<i class="bx bx-play"></i>';
        playButton.classList.add("play-button");
        bannerButtons.appendChild(infoButton);
        bannerButtons.appendChild(playButton);
        bannerItem.appendChild(bannerName);
        bannerItem.appendChild(bannerButtons);

        bannerList.appendChild(bannerItem);
        playButton.addEventListener("click", () => {
          playButton.disabled = true;
          playButton.innerHTML = '<i class="bx bx-loader-alt bx-spin"></i>';
          const xhr = new XMLHttpRequest();
          xhr.open(
            "POST",
            `http://localhost:3000/launch?name=${banner.Name}`,
            true
          );
          xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
              showPopupBox("Launched Successfully!", "😎", 5000);
              playButton.innerHTML = '<i class="bx bx-play"></i>';
              playButton.disabled = false;
            } else if (xhr.readyState === 4 && xhr.status === 400) {
              showPopupBox("Failed to launch!", "😢", 5000);
              playButton.innerHTML = '<i class="bx bx-play"></i>';
              playButton.disabled = false;
            }
          };
          xhr.send();
        });

        infoButton.addEventListener("click", () => {
          infoButton.disabled = true;
          infoButton.innerHTML = '<i class="bx bx-loader-alt bx-spin"></i>';
          const xhr = new XMLHttpRequest();
          xhr.open(
            "GET",
            `http://localhost:3000/uninstall?name=${banner.Name}`,
            true
          );
          xhr.onreadystatechange = function () {
            if (xhr.readyState === 4 && xhr.status === 200) {
              showPopupBox("Uninstalled Successfully!", "😎", 5000);
              infoButton.innerHTML = '<i class="bx bx-trash"></i>';
              infoButton.disabled = false;
              fetchInstalledContent();
            } else if (xhr.readyState === 4 && xhr.status === 400) {
              showPopupBox("Failed to uninstall!", "😢", 5000);
              infoButton.innerHTML = '<i class="bx bx-trash"></i>';
              infoButton.disabled = false;
            }
          };
          xhr.send();
        });
      });
    });
}

//About me button

/*
const theAboutMeButton = document.getElementById("aboutme");

theAboutMeButton.addEventListener("click", (event) => {
  event.preventDefault();
  theAboutMeButton.classList.add("loading");
  showPopupBox("Redirecting to about me page...");
  setTimeout(() => {
    theAboutMeButton.classList.remove("loading");
    document.location = "https://printedwaste.live/about/index.html";
  }, 3000);
});
*/

function unixTimestampToString(unixTimestamp) {
  const currentTimestamp = Math.floor(Date.now() / 1000);
  const timeDiff = currentTimestamp - unixTimestamp;

  if (timeDiff < 60) {
    return "just now";
  } else if (timeDiff < 3600) {
    const minutes = Math.floor(timeDiff / 60);
    return `${minutes} minute${minutes > 1 ? "s" : ""} ago`;
  } else if (timeDiff < 86400) {
    const hours = Math.floor(timeDiff / 3600);
    return `${hours} hour${hours > 1 ? "s" : ""} ago`;
  } else if (timeDiff < 604800) {
    const days = Math.floor(timeDiff / 86400);
    return `${days} day${days > 1 ? "s" : ""} ago`;
  } else {
    const weeks = Math.floor(timeDiff / 604800);
    return `${weeks} week${weeks > 1 ? "s" : ""} ago`;
  }
}

function showDownloadMenu(Gamename, GaneDownload, GameLaunch, GameSize) {
  const xhr = new XMLHttpRequest();
  xhr.open("POST", `http://localhost:3000/gameStatus?name=${Gamename}`, true);
  xhr.onreadystatechange = function () {
    if (xhr.readyState === 4 && xhr.status === 200) {
      showDownloadSection();
    } else if (xhr.readyState === 4 && xhr.status === 404) {
      fetch("http://localhost:3000/drives")
        .then((response) => response.json())
        .then((data) => {
          const availableDrives = document.getElementById("download-status");

          // Build the drive list string
          let driveList = "";
          data.Drives.forEach((drive) => {
            driveList += `${drive.Drive} ${drive.DriveSpace} | `;
          });

          // Remove the trailing '|' character from the drive list string
          driveList = driveList.slice(0, -2);
          // Update the text content of the download status element with the drive list string
          availableDrives.textContent = driveList;
        });

      document.getElementById("downloader-game-name").textContent = Gamename;
      document.getElementById(
        "downloadlocation"
      ).value = `C:\\CloudForce\\${Gamename}`;
      let homeSection = document.querySelector("#dashboard-section");
      let filesSection = document.querySelector("#files-section");
      let settingsSection = document.querySelector("#settings-section");
      let downloadSection = document.querySelector("#downloader-section");
      let installedSection = document.querySelector("#installed-section");

      homeSection.style.display = "none";
      filesSection.style.display = "none";
      settingsSection.style.display = "none";
      downloadSection.style.display = "block";
      installedSection.style.display = "none";
    }
  };
  xhr.send();
}

window.addEventListener("load", () => {
  let downloading = false;
  showPopupBox("Welcome to CF Game Center!", "👋", 2000);
  fetch("https://files.zortos.me/Files/CF%20GC%20Resources/GameCenter.json")
    .then((response) => response.json())
    .then((data) => {
      const gameList = document.querySelector(".game-list");
      // Loop through the API data to create the HTML structure for each game item
      data.crack.forEach((game) => {
        const gameItem = document.createElement("div");
        gameItem.className = "game-item";
        gameItem.style.animation = "fadeIn 1s ease-in-out;";

        const gamePoster = document.createElement("div");
        gamePoster.className = "game-poster";
        const posterImg = document.createElement("img");
        posterImg.src = game.GamePoster;
        gamePoster.appendChild(posterImg);

        const gameName = document.createElement("div");
        gameName.className = "game-name";
        gameName.textContent = game.Gamename;

        gameItem.appendChild(gamePoster);
        gameItem.appendChild(gameName);
        gameList.appendChild(gameItem);

        gameItem.addEventListener("click", () => {
          // handle click event here
          if (downloading) {
            showPopupBox("Something is already downloading!", "🤔", 5000);
          } else {
            showDownloadMenu(
              game.Gamename,
              game.GaneDownload,
              game.GameLaunch,
              game.GameSize
            );
          }
        });
      });
    });

  //Download stuff
  const downloadButton = document.getElementById("download-button");
  downloadButton.addEventListener("click", (event) => {
    event.preventDefault();
    downloadButton.textContent = "Loading...";
    downloadButton.disabled = true;
    const gameName = document.getElementById(
      "downloader-game-name"
    ).textContent;
    fetch("https://files.zortos.me/Files/CF%20GC%20Resources/GameCenter.json")
      .then((response) => response.json())
      .then((data) => {
        const { GameDownload, Gamelaunch } = data.crack.find(
          (game) => game.Gamename === gameName
        );
        const [drive, name] = GameDownload.split(":");
        const path = document.getElementById("downloadlocation").value;
        const regex = /^[a-zA-Z]:\\(?:[^\\/:*?"<>|]+\\)*[^\\/:*?"<>|]*$/;
        let disk, directory;
        if (regex.test(path)) {
          [disk, ...dirs] = path.split("\\");
          directory = dirs.join("\\");
        } else {
          showPopupBox("Invalid path!", "😢", 5000);
          downloadButton.textContent = "Install";
          downloadButton.disabled = false;
          return;
        }
        const xhr = new XMLHttpRequest();
        xhr.open(
          "POST",
          `http://localhost:3000/download?drive=${drive}&name=${name}&disk=${disk}&directory=${directory}&gameLaunch=${Gamelaunch}`,
          true
        );
        xhr.onreadystatechange = function () {
          if (xhr.readyState === 4 && xhr.status === 200) {
            showPopupBox("Download completed!", "😎", 5000);
            downloadButton.textContent = "Install";
            showDownloadSection();
            downloadButton.disabled = false;
          } else if (xhr.readyState === 4 && xhr.status === 400) {
            showPopupBox("Already installed!", "😢", 5000);
            downloadButton.textContent = "Install";
            downloadButton.disabled = false;
          } else {
            console.log(xhr.status);
          }
        };
        xhr.send();
      });
  });
});
