console.log("Loaded");

let sidebar = document.querySelector(".sidebar");
let closeBtn = document.querySelector("#btn");
let searchBtn = document.querySelector(".bx-search");

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
    setTimeout(async function () {
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
/*
searchBtn.addEventListener("click", () => {
  sidebar.classList.toggle("open");
  menuBtnChange();
});
*/

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

  homeSection.style.display = "block";
  filesSection.style.display = "none";
  settingsSection.style.display = "none";
}

function showSettingsSection() {
  let homeSection = document.querySelector("#dashboard-section");
  let filesSection = document.querySelector("#files-section");
  let settingsSection = document.querySelector("#settings-section");

  homeSection.style.display = "none";
  filesSection.style.display = "none";
  settingsSection.style.display = "block";
}

function showFilesSection() {
  let homeSection = document.querySelector("#dashboard-section");
  let filesSection = document.querySelector("#files-section");
  let settingsSection = document.querySelector("#settings-section");

  homeSection.style.display = "none";
  filesSection.style.display = "block";
  settingsSection.style.display = "none";
}

function showLoginForm() {
  window.location.href = "https://printedwaste.live/login";
}

//CloudForce Button

/*
const theCloudForceButton = document.getElementById("cloudforce");

theCloudForceButton.addEventListener("click", (event) => {
  event.preventDefault();
  theCloudForceButton.classList.add("loading");
  showPopupBox("Redirecting to cloudforce page...");
  setTimeout(() => {
    theCloudForceButton.classList.remove("loading");
    document.location = "https://printedwaste.live/cloudforce/";
  }, 3000);
});
*/

//Moderation Utility Updates
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

window
  .addEventListener("load", async () => {
    showPopupBox("Welcome to CF game center!", "👋", 2000);

    // Fetch the JSON API data
    fetch("https://files.zortos.me/Files/CF%20GC%20Resources/GameCenter.json")
      .then((response) => response.json())
      .then((data) => {
        // Loop through the API data to create the HTML structure for each game item
        const gameList = document.querySelector(".game-list");
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

          gameItem.addEventListener("click", async () => {
            // handle click event here
            showPopupBox(`Clicked on ${game.Gamename}`, "🎮", 3000);
          });
        });
      });
  })
  .catch((error) => console.error(error));
