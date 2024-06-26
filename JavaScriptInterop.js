// JavaScriptInterop.js Custom delete button to delete numerals of an inputBox. 
//This is done in the Test1 page.
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


