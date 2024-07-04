$(document).ready(function () {
    // Function to show content based on selected language
    function updateVisibility(selectedLanguage) {
        // Hide all input fields initially
        $('.form-group').hide();
        // Hide all h5 elements initially
        $('h5').hide();

        // Normalize selectedLanguage to standard identifiers
        switch (selectedLanguage) {
            case 'English':
                $('.english-group').show();
                $('#majorName').show();
                break;
            case 'العربية': // Arabic
                $('.arabic-group').show();
                $('#majorNamear').show();
                break;
            case 'Türkçe': // Turkish
                $('.turkish-group').show();
                $('#majorNametr').show();
                break;
            default:
                // Default to English if selected language is unknown or not handled
                $('.english-group').show();
                $('#majorName').show();
                break;
        }
    }

    // Function to get the language from URL path
    function getLanguageFromUrl() {
        var path = window.location.pathname;
        if (path.includes('/Language/English')) {
            return 'English';
        } else if (path.includes('/Language/Arabic')) {
            return 'العربية'; // Arabic
        } else if (path.includes('/Language/Turkish')) {
            return 'Türkçe'; // Turkish
        }
        // Default to English if no language found in path
        return 'English';
    }

    // Check sessionStorage for the last selected language
    var storedLanguage = sessionStorage.getItem('selectedLanguage');

    // If there is no stored language, get from URL path and set sessionStorage
    if (!storedLanguage) {
        storedLanguage = getLanguageFromUrl();
        sessionStorage.setItem('selectedLanguage', storedLanguage);
    }

    // Update visibility based on stored language
    updateVisibility(storedLanguage);

    // Event listener for language selection
    $('.language-option').click(function (e) {
        e.preventDefault(); // Prevent default link behavior

        // Get the selected language data attribute
        var selectedLanguage = $(this).data('language');

        // Store the selected language in sessionStorage
        sessionStorage.setItem('selectedLanguage', selectedLanguage);

        // Update visibility based on selected language
        updateVisibility(selectedLanguage);
    });
});
