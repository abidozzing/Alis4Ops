


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

        // Clear existing content and insert the correct icon
        event.target.innerHTML = '';
        event.target.insertAdjacentHTML("afterbegin", `<i class="fas fa-${draggableElementData}"></i>`);

        // Check if all items are placed correctly and show the Play Again button
        if (document.querySelectorAll('.droppable:not(.dropped)').length === 0) {
            showPlayAgainButton();
        }
    }
}

// Reset the game to its initial state
function resetGame() {
    const droppableElements = document.querySelectorAll(".droppable");
    const draggableElements = document.querySelectorAll(".draggable");

    droppableElements.forEach((elem) => {
        // Remove extra classes that might have been added
        elem.classList.remove("dropped", "droppable-hover");

        // Clear existing HTML content
        elem.innerHTML = '';

        //// Retrieve the original text
        //const originalText = elem.getAttribute('data-original-text') || '';

        const numbers = Array.from({ length: 10 }, (_, i) => i);

        // Shuffle the array
        for (let i = numbers.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [numbers[i], numbers[j]] = [numbers[j], numbers[i]];
        }

        // Create and insert the shuffled elements
        numbers.forEach(num => {
            const div = document.createElement('div');
            div.className = 'droppable';
            div.setAttribute('data-draggable-id', num);
            div.setAttribute('data-original-text', num);
            div.innerHTML = `<span>${num}</span>`;
            container.appendChild(div);
        });

        // Insert the original text inside a <span> to apply CSS styling
        elem.insertAdjacentHTML("afterbegin", `<span>${originalText}</span>`);

        // Clear any inline styles to ensure default CSS is applied
        elem.style.backgroundColor = ''; // Remove any inline background color
    });

    draggableElements.forEach((elem) => {
        // Reset draggable elements
        elem.classList.remove("dragged");
        elem.setAttribute("draggable", "true");
    });

    hidePlayAgainButton(); // Call your method to hide the "Play Again" button
    setupEventListeners(); // Reattach event listeners
}



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
    }
}

// Hide the Play Again button
function hidePlayAgainButton() {
    const playAgainButton = document.getElementById("play-again");
    if (playAgainButton) {
        playAgainButton.style.display = "none";
    }
}

// Add the play again button and set up its functionality
function setupPlayAgainButton() {
    const playAgainButton = document.getElementById("play-again");

    if (playAgainButton) {
        playAgainButton.addEventListener("click", () => {
            resetGame();
        });
    }
}

function resetGame1() {
    window.location.reload(false)
}
// Run the initial setup
setupEventListeners();
setupPlayAgainButton();
