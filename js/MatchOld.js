// Call these functions immediately on script load
storeIconCounts();
setupEventListeners();
setupPlayAgainButton();

// Store the number of icons in each droppable
function storeIconCounts() {
    const droppableElements = document.querySelectorAll(".droppable");

    droppableElements.forEach(elem => {
        // Store the count of icons in each droppable box
        const iconCount = elem.querySelectorAll('i').length;
        elem.dataset.iconCount = iconCount;

        // For debugging purposes (optional)
        console.log(`Box ID: ${elem.getAttribute("data-draggable-id")} - Number of Icons: ${iconCount}`);
    });
}

// Initialize the game and set up event listeners
function setupEventListeners() {
    const draggableElements = document.querySelectorAll(".draggable");
    const droppableElements = document.querySelectorAll(".droppable");

    // Add event listeners to draggable elements
    draggableElements.forEach((elem) => {
        elem.removeEventListener("dragstart", dragStart);
        elem.addEventListener("dragstart", dragStart);
    });

    // Add event listeners to droppable elements
    droppableElements.forEach((elem) => {
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
}

// Handle when an item is dragged over a droppable area
function dragEnter(event) {
    event.preventDefault(); // Ensure that drop is allowed
    if (!event.target.classList.contains("dropped")) {
        event.target.classList.add("droppable-hover");
    }
}

// Handle the dragover event, required to allow dropping
function dragOver(event) {
    event.preventDefault(); // Prevent default to allow drop
}

// Handle when an item leaves a droppable area
function dragLeave(event) {
    if (!event.target.classList.contains("dropped")) {
        event.target.classList.remove("droppable-hover");
    }
}

function drop(event) {
    event.preventDefault();
    event.stopPropagation();

    event.target.classList.remove("droppable-hover");

    const draggableElementId = event.dataTransfer.getData("text");
    const droppableElement = event.target;
    const droppableElementId = droppableElement.getAttribute("data-draggable-id");

    const iconCountInDroppable = parseInt(droppableElement.dataset.iconCount, 10);

    if (parseInt(draggableElementId, 10) === iconCountInDroppable) {
        const draggableElement = document.getElementById(draggableElementId);

        droppableElement.classList.add("dropped");
        droppableElement.style.backgroundColor = window.getComputedStyle(draggableElement).color;

        draggableElement.classList.add("dragged");
        draggableElement.setAttribute("draggable", "false");

        droppableElement.innerHTML = '';
        droppableElement.insertAdjacentHTML("afterbegin", `<i class="fas fa-${draggableElementId}"></i>`);

        if (document.querySelectorAll('.droppable:not(.dropped)').length === 0) {
            showPlayAgainButton();
        }
    } else {
        droppableElement.classList.add("incorrect-drop");
        setTimeout(() => droppableElement.classList.remove("incorrect-drop"), 1000);
    }
}


// Reset the game to its initial state
//function resetGame() {
//    const droppableElements = document.querySelectorAll(".droppable");
//    const draggableElements = document.querySelectorAll(".draggable");

//    droppableElements.forEach((elem) => {
//        elem.classList.remove("dropped", "droppable-hover", "incorrect-drop");
//        elem.innerHTML = '';
//        const iconCount = elem.dataset.iconCount || 0;
//        for (let i = 0; i < iconCount; i++) {
//            elem.insertAdjacentHTML("beforeend", `<i class="fas fa-${elem.getAttribute('data-draggable-id')}" style="font-size:2rem; color: ${getRandomColor()};"></i>`);
//        }
//        elem.style.backgroundColor = ''; // Remove any inline background color
//    });

//    draggableElements.forEach((elem) => {
//        elem.classList.remove("dragged");
//        elem.setAttribute("draggable", "true");
//    });

//    document.getElementById('play-again').style.display = 'none';
//}
// Reset the game to its initial state
//////////////////////////////////////////////////////////////////////////
// Function to reset the game to its initial state
function resetGame() {
    const droppableElements = document.querySelectorAll(".droppable");
    const draggableElements = document.querySelectorAll(".draggable");

    // Clear existing content and classes from droppable elements
    droppableElements.forEach(elem => {
        elem.classList.remove("dropped", "droppable-hover");
        elem.innerHTML = '';
        elem.style.backgroundColor = ''; // Remove inline background color
    });

    // Get randomized counts for each droppable
    const randomizedIconCounts = getRandomizedIconCounts(droppableElements.length);

    // Load icons from JSON file and log them
    loadIcons().then(icons => {
        console.log("Loaded icons:", icons); // Log the loaded icons

        // Populate droppable elements with randomized icons
        droppableElements.forEach((elem, index) => {
            const iconCount = randomizedIconCounts[index];
            for (let i = 0; i < iconCount; i++) {
                // Choose a random icon from the loaded icons
                const iconClass = getRandomIconClass(icons);
                // Insert an icon element into the droppable element
                elem.insertAdjacentHTML("beforeend", `<i class="fas ${iconClass}" style="color: ${getRandomColor()};"></i>`);
            }
            elem.dataset.iconCount = iconCount; // Store the number of icons
        });

        // Reset draggable elements
        draggableElements.forEach(elem => {
            elem.classList.remove("dragged");
            elem.setAttribute("draggable", "true");
        });

        // Hide the Play Again button
        document.getElementById('play-again').style.display = 'none';

        // Reinitialize event listeners
        storeIconCounts();  // Ensure icon counts are stored for the new game
        setupEventListeners();  // Reattach event listeners
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

// Get a random list of icon counts for each droppable element
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
    playAgainButton.addEventListener('click', () => {
        resetGame();
        //storeIconCounts();
        //setupEventListeners();
    });
}

// Get a random color
function getRandomColor() {
    const colors = ["#ff6384", "#0000ff", "#36a2eb", "#128912", "#9966ff", "#4bc0c0", "#ffce56"];
    return colors[Math.floor(Math.random() * colors.length)];
}
