// Define window.dragDropFunction for drag-and-drop operations
window.dragDropFunction = {
    initializeDragDrop: function () {
        console.log('Initializing drag-and-drop...');

        // Attach dragstart event listeners to draggable icons
        var icons = document.querySelectorAll('img[data-icon-id]');
        icons.forEach(icon => {
            icon.addEventListener('dragstart', function (e) {
                var iconId = parseInt(icon.getAttribute('data-icon-id'));
                var clientX = e.clientX;
                var clientY = e.clientY;
                window.dragDropFunction.startDrag(iconId, clientX, clientY);
            });

            icon.addEventListener('dragend', function (e) {
                var iconId = parseInt(icon.getAttribute('data-icon-id'));
                var clientX = e.clientX;
                var clientY = e.clientY;
                window.dragDropFunction.dropIcon(iconId, clientX, clientY);
            });
        });

        // Define drop zone behavior
        var dropZone = document.getElementById('drop-zone');
        dropZone.addEventListener('dragover', function (e) {
            e.preventDefault();
            dropZone.style.backgroundColor = 'lightgreen';
        });

        dropZone.addEventListener('dragleave', function (e) {
            dropZone.style.backgroundColor = 'lightblue';
        });

        dropZone.addEventListener('drop', function (e) {
            e.preventDefault();
            var iconId = parseInt(e.dataTransfer.getData('iconId'));
            var clientX = e.clientX;
            var clientY = e.clientY;
            window.dragDropFunction.dropIcon(iconId, clientX, clientY);
            dropZone.style.backgroundColor = 'lightblue';
        });
    },

    startDrag: function (iconId, x, y) {
        console.log(`Starting drag for icon ${iconId} at (${x}, ${y})`);
        // Implement logic here to handle the start of drag operation
        // For example: Highlight the dragged icon, update its position, etc.
        var iconElement = document.querySelector(`img[data-icon-id="${iconId}"]`);
        if (iconElement) {
            iconElement.style.opacity = '0.5'; // Example: Reduce opacity while dragging
            iconElement.style.border = '2px dashed red'; // Example: Change border style
        }
    },

    dropIcon: function (iconId, x, y) {
        console.log(`Dropping icon ${iconId} at (${x}, ${y})`);
        // Implement logic here to handle the drop operation
        // For example: Move the icon to a new position, check drop zone, etc.
        var iconElement = document.querySelector(`img[data-icon-id="${iconId}"]`);
        if (iconElement) {
            iconElement.style.opacity = '1'; // Example: Restore opacity after drop
            iconElement.style.border = 'none'; // Example: Remove border after drop
            iconElement.style.left = `${x}px`; // Example: Set new left position
            iconElement.style.top = `${y}px`; // Example: Set new top position
        }
    }
};

// Function to delete a character in an input field
window.blazorFunctions = {
    deleteCharacter: function (element) {
        var input = document.getElementById(element);
        var cursorPos = input.selectionStart;
        var textBeforeCursor = input.value.substring(0, cursorPos);
        var textAfterCursor = input.value.substring(cursorPos + 1);
        input.value = textBeforeCursor + textAfterCursor;
        input.setSelectionRange(cursorPos, cursorPos); // Set the same position as the cursor after deletion
        input.focus(); // Set input box in focus
    }
};

// Function to change button color
window.changeButtonColor = function (color) {
    var button = document.getElementById("changeColorButton");
    if (button) {
        button.style.backgroundColor = color;
    }
};
