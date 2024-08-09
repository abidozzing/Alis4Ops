(function () {
    function sayHello(name) {
        console.log(`Hello, ${name}!`);
    }
    window.myNamespace = window.myNamespace || {};
    window.myNamespace.onLoad = {
        sayHello: sayHello
    };
})();



storeIconCounts();
// Call these functions to set up event listeners
setupMouseListeners();
setupPlayAgainButton();
//setupTouchListeners();



// Store the number of icons in each boxes
function storeIconCounts() {
    const boxesElements = document.querySelectorAll(".boxes");

    boxesElements.forEach(elem => {
        // Store the count of icons in each boxes box
        const iconCount = elem.querySelectorAll('i').length;
        elem.dataset.iconCount = iconCount;

        // For debugging purposes (optional)
        console.log(`Box ID: ${elem.getAttribute("box-id")} - Number of Icons: ${iconCount}`);
    });
}

// Initialize the game and set up event listeners
function setupMouseListeners() {
    //digitElements are the digits 0 to 9
    //boxesElements are boxes to drop the digits
    const digitElements = document.querySelectorAll(".digit");
    const boxesElements = document.querySelectorAll(".boxes");
    const iconElements = document.querySelectorAll(".icon");

    // Add event listeners to digit elements digits 0 to 9
    digitElements.forEach((elem) => {
        elem.removeEventListener("dragstart", dragStart);
        elem.addEventListener("dragstart", dragStart);
    });

    // Add event listeners to boxes elements the boxes
    boxesElements.forEach((elem) => {
        elem.removeEventListener("dragenter", dragEnter);
        elem.removeEventListener("dragover", dragOver);
        elem.removeEventListener("dragleave", dragLeave);
        elem.removeEventListener("drop", drop);
        elem.addEventListener("dragenter", dragEnter);
        elem.addEventListener("dragover", dragOver);
        elem.addEventListener("dragleave", dragLeave);
        elem.addEventListener("drop", drop);
    });

    // Add event listeners to boxes elements the boxes
    digitElements.forEach((elem) => {
        elem.removeEventListener("dragenter", dragEnter);
        elem.removeEventListener("dragover", dragOver);
        elem.removeEventListener("dragleave", dragLeave);
        elem.removeEventListener("drop", drop);
        elem.addEventListener("dragenter", dragEnter);
        elem.addEventListener("dragover", dragOver);
        elem.addEventListener("dragleave", dragLeave);
        elem.addEventListener("drop", drop);
    });

    // Add event listeners to boxes elements the boxes
    iconElements.forEach((elem) => {
        elem.removeEventListener("dragenter", dragEnter);
        elem.removeEventListener("dragover", dragOver);
        elem.removeEventListener("dragleave", dragLeave);
        elem.removeEventListener("drop", drop);
        elem.addEventListener("dragenter", dragEnter);
        elem.addEventListener("dragover", dragOver);
        elem.addEventListener("dragleave", dragLeave);
        elem.addEventListener("drop", drop);
    });

}
// Handle the start of a drag event
function dragStart(event) {
    event.dataTransfer.setData("text", event.target.id);
    console.log("Drag started");
}

// Handle when an item is dragged over a boxes area
function dragEnter(event) {
    event.preventDefault(); // Ensure that drop is allowed
    if (!event.target.classList.contains("dropped")) {
        event.target.classList.add("boxes-hover");
        event.target.classList.add("icon-hover");
    }
    console.log("Drag entered boxes area");
}

// Handle the dragover event, required to allow dropping
function dragOver(event) {
    event.preventDefault(); // Prevent default to allow drop
    console.log("Drag over boxes area");
}

// Handle when an item leaves a boxes area
function dragLeave(event) {
    if (!event.target.classList.contains("dropped")) {
        event.target.classList.remove("boxes-hover");
        event.target.classList.remove("icon-hover");
    }
    console.log("Drag left boxes area");
}

function drop(event) {
    event.preventDefault();
    event.stopPropagation();
    console.log("Dropped");
    event.target.classList.remove("boxes-hover");
    const Box = document.querySelector('.boxes');
    const digitElementId = event.dataTransfer.getData("text");
    const boxesElement = event.target;
    // Identify the closest box ancestor from the drop target
    let targetElement = event.target;

    const targetBox = targetElement.closest('.boxes');

    const boxId = targetBox.getAttribute('box-id');
    const iconCountInDroppable = parseInt(boxesElement.dataset.iconCount, 10);
    // Determine if the drop target is an icon or the drop zone itself
    const dropZone = event.target.closest('.boxes') || Box;

    const box1 = document.querySelector(`.boxes[box-id="${boxId}"]`);
    // Get the total number of icons in the drop zone
    const numberOfIcons = box1.querySelectorAll('.icon').length;

    if (parseInt(digitElementId, 10) === numberOfIcons || parseInt(digitElementId, 10) === numberOfIcons) {
        const digitElement = document.getElementById(digitElementId);

        boxesElement.classList.add("dropped");
        //iconsElement.classList.add("dropped");
        boxesElement.style.backgroundColor = window.getComputedStyle(digitElement).color;

        digitElement.classList.add("dragged");
        digitElement.setAttribute("digit", "false");
        const targetBox = targetElement.closest('.boxes');
        targetBox.innerHTML = '';
        boxesElement.innerHTML = '';
        boxesElement.insertAdjacentHTML("afterbegin", `<i class="fas fa-${digitElementId}"></i>`);
        //iconsElement.insertAdjacentHTML("afterbegin", `<i class="fas fa-${digitElementId}"></i>`);

        if (document.querySelectorAll('.boxes:not(.dropped)').length === 0 || document.querySelectorAll('.icon:not(.dropped)').length === 0) {
            console.log("Drop Successful");
            showPlayAgainButton();
        }
    } else {
        boxesElement.classList.add("incorrect-drop");
        console.log("Drop Unsuccessful");
        setTimeout(() => boxesElement.classList.remove("incorrect-drop"), 1000);
    }
}


// Function to reset the game to its initial state
function resetGame() {
    const boxesElements = document.querySelectorAll(".boxes");
    const digitElements = document.querySelectorAll(".digit");
    //const iconelements = document.querySelectorAll(".icon");

    // Clear existing content and classes from boxes elements
    boxesElements.forEach(elem => {
        elem.classList.remove("dropped", "boxes-hover");
        elem.innerHTML = '';
        elem.style.backgroundColor = ''; // Remove inline background color
    });

    // Get randomized counts for each boxes
    const randomizedIconCounts = getRandomizedIconCounts(9);

    // Load icons from JSON file and log them
    loadIcons().then(icons => {
        console.log("Loaded icons:", icons.iconCount); // Log the loaded icons

        // Populate boxes elements with randomized icons
        boxesElements.forEach((elem, index) => {
            console.log("Box Num Index:", index);

            const iconCount = randomizedIconCounts[index];
            console.log("Icon Count:", iconCount);
            for (let i = 0; i < iconCount; i++) {
                iconsElementId = iconCount;
                // Choose a random icon from the loaded icons
                const iconClass = getRandomIconClass(icons);
                console.log("Icon Class:", iconClass);
                elem.insertAdjacentHTML("beforeend",
                    `<i class="icon ${iconClass}" color: ${getRandomColor()};">
                </i>`);
            }
            elem.dataset.iconCount = iconCount; // Store the number of icons
        });

        // Reset digit elements
        digitElements.forEach(elem => {
            elem.classList.remove("dragged");
            elem.setAttribute("digit", "true");
        });

        // Hide the Play Again button
        document.getElementById('play-again').style.display = 'none';

        // Reinitialize event listeners
        storeIconCounts();  // Ensure icon counts are stored for the new game
        setupMouseListeners();  // Reattach event listeners
    });
}

// Function to load icons from JSON file
function loadIcons() {
    return fetch('images/FontAwesomeJson/FontAwesomeV509Free.json')
        .then(response => response.json())
        .then(data => {
            return data; // Return the loaded icons
        })
        .catch(error => {
            console.error("Error loading icons:", error);
            return []; // Return an empty array if there is an error
        });
}

// Function to get a random icon class from the list of icons
function getRandomIconClass(icons) {
    if (icons.length === 0) {
        return 'fa-question'; // Fallback icon class
    }
    const randomIndex = Math.floor(Math.random() * icons.length);
    return icons[randomIndex]; // Return a random icon class
}

// Get a random list of icon counts for each boxes element
function getRandomizedIconCounts(numBoxes) {
    const counts = Array.from({ length: numBoxes }, (_, i) => i + 1);
    return shuffleArray(counts);
}

// Shuffle array using Fisher-Yates algorithm
function shuffleArray(array) {
    let currentIndex = array.length, randomIndex;
    while (currentIndex !== 0) {
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;
        [array[currentIndex], array[randomIndex]] = [array[randomIndex], array[currentIndex]];
    }
    return array;
}

// Generate a random color
function getRandomColor() {
    const colors = ["#ff6384", "#0000ff", "#36a2eb", "#128912", "#9966ff", "#4bc0c0", "#ffce56"];
    return colors[Math.floor(Math.random() * colors.length)];
}

//////////////////////////////////////////////////////////////////

// Show the Play Again button
function showPlayAgainButton() {
    const playAgainButton = document.getElementById("play-again");
    if (playAgainButton) {
        playAgainButton.style.display = "block";
        playAgainButton.style.backgroundColor = "#007bff"; // Set button background color
        playAgainButton.style.color = "#fff"; // Set button text color
        playAgainButton.style.border = "none"; // Optional: Remove button border
        playAgainButton.style.padding = "10px 20px"; // Optional: Add padding
        playAgainButton.style.borderRadius = "5px"; // Optional: Add border radius
        playAgainButton.style.cursor = "pointer"; // Optional: Change cursor on hover
        playAgainButton.style.marginTop = "20px";
    }
}

// Set up the Play Again button functionality
function setupPlayAgainButton() {
    const playAgainButton = document.getElementById('play-again');
    if (playAgainButton) {
        playAgainButton.addEventListener("click", () => {
            resetGame();
        });
    }
    //storeIconCounts();
    //setupMouseListeners();
}

// Get a random color
function getRandomColor() {
    const colors = ["#ff6384", "#0000ff", "#36a2eb", "#128912", "#9966ff", "#4bc0c0", "#ffce56"];
    return colors[Math.floor(Math.random() * colors.length)];
}
