document.addEventListener("DOMContentLoaded", function () {
    var contactButton = document.getElementById("contactButton");

    function adjustButtonPosition(direction) {
        if (direction === 'rtl') {
            contactButton.style.marginRight = 'auto';
            contactButton.style.marginLeft = '0';
        } else {
            contactButton.style.marginLeft = 'auto';
            contactButton.style.marginRight = '0';
        }
    }

    // Initial adjustment based on current direction
    var currentDir = document.documentElement.getAttribute('dir');
    adjustButtonPosition(currentDir);

    // Event listener for language options
    document.querySelectorAll('.language-option').forEach(function (element) {
        element.addEventListener('click', function (event) {
            event.preventDefault();
            var selectedDir = this.getAttribute('data-dir');
            document.documentElement.setAttribute('dir', selectedDir);
            adjustButtonPosition(selectedDir);
        });
    });
});
