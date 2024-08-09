// Function to initialize and render the game
function initializeGame() {
    const draggableContainer = document.getElementById("draggable-container");
    const droppableContainer = document.getElementById("droppable-container");

    // Clear existing content
    draggableContainer.innerHTML = '';
    droppableContainer.innerHTML = '';

    // Create draggable elements
    for (let i = 0; i <= 9; i++) {
        const div = document.createElement('div');
        div.className = `fas fa-${i} draggable`;
        div.draggable = true;
        div.style.color = getRandomColor(); // Apply random color
        div.id = i;
        draggableContainer.appendChild(div);
    }

    // Create droppable elements
    const numbers = Array.from({ length: 10 }, (_, i) => i);

    // Shuffle the array
    for (let i = numbers.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [numbers[i], numbers[j]] = [numbers[j], numbers[i]];
    }

    numbers.forEach(num => {
        const div = document.createElement('div');
        div.className = 'droppable';
        div.setAttribute('data-draggable-id', num);
        div.setAttribute('data-original-text', num);
        div.innerHTML = `<span>${num}</span>`;
        droppableContainer.appendChild(div);
    });

    // Set up event listeners
    setupEventListeners();
    setupPlayAgainButton();
}

// Get a random color for draggable elements
function getRandomColor() {
    const colors = ['#ff6384', '#36a2eb', '#ffce56', '#9966ff', '#4bc0c0'];
    return colors[Math.floor(Math.random() * colors.length)];
}

// Function to set up event listeners for drag and drop
function setupEventListeners() {
    const draggableElements = document.querySelectorAll(".draggable");
    const droppableElements = document.querySelectorAll(".droppable");

    draggableElements.forEach((elem) => {
        elem.removeEventListener("dragstart", dragStart);
        elem.addEventListener("dragstart", dragStart);
    });

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

// Handle the drop event
function drop(event) {
    event.preventDefault();
    event.stopPropagation(); // Prevent default handling

    event.target.classList.remove("droppable-hover");

    const draggableElementData = event.dataTransfer.getData("text");
    const droppableElementData = event.target.getAttribute("data-draggable-id");

    if (draggableElementData === droppableElementData) {
        const draggableElement = document.getElementById(draggableElementData);

        event.target.classList.add("dropped");
        event.target.style.backgroundColor = window.getComputedStyle(draggableElement).color;

        draggableElement.classList.add("dragged");
        draggableElement.setAttribute("draggable", "false");

        event.target.innerHTML = '';
        event.target.insertAdjacentHTML("afterbegin", `<i class="fas fa-${draggableElementData}"></i>`);

        if (document.querySelectorAll('.droppable:not(.dropped)').length === 0) {

            initializeGame() 
        }
    }
}

// Reset the game to its initial state
function resetGame() {
    initializeGame();
    //hidePlayAgainButton(); // Hide the "Play Again" button
}

// Show the Play Again button
function showPlayAgainButton() {
    const playAgainButton = document.getElementById("play-again");
    if (playAgainButton) {
        playAgainButton.style.display = "block";
        playAgainButton.style.backgroundColor = "#007bff";
        playAgainButton.style.color = "#fff";
        playAgainButton.style.border = "none";
        playAgainButton.style.padding = "10px 20px";
        playAgainButton.style.borderRadius = "5px";
        playAgainButton.style.cursor = "pointer";
    }
}

// Hide the Play Again button
function hidePlayAgainButton() {
    const playAgainButton = document.getElementById("play-again");
    if (playAgainButton) {
        playAgainButton.style.display = "none";
    }
}

// Set up the Play Again button and its functionality
function setupPlayAgainButton() {
    const playAgainButton = document.getElementById("play-again");

    if (playAgainButton) {
        playAgainButton.addEventListener("click", () => {
            resetGame();
        });
    }
}

// Initial setup
initializeGame();
