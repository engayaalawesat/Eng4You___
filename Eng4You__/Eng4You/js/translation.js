    function googleTranslateElementInit() {
        new google.translate.TranslateElement({
            pageLanguage: 'en',  // Set the page language (optional)
            includedLanguages: 'en,tr,ar',  // Languages to include in the dropdown
            layout: google.translate.TranslateElement.InlineLayout.SIMPLE,  // Set the layout
            autoDisplay: false  // Prevent automatic display of the widget
        }, 'google_translate_element');
        }