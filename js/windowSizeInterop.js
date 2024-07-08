// wwwroot/js/windowSizeInterop.js

document.addEventListener("DOMContentLoaded", function () {
    window.getWindowSize = function () {
        // Function implementation to get window size
        return {
            width: window.innerWidth,
            height: window.innerHeight
        };
    };
});