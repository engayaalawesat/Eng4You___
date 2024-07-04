document.addEventListener('DOMContentLoaded', function () {
    const selectedLanguage = localStorage.getItem('selectedLanguage');
    if (selectedLanguage && selectedLanguage.trim() !== "") {
        document.querySelector('.dropbtn span').textContent = selectedLanguage;
    } 

    document.querySelectorAll('.language-option').forEach(option => {
        option.addEventListener('click', function (event) {
            event.preventDefault();
            const selectedLanguage = this.dataset.language;
            document.querySelector('.dropbtn span').textContent = selectedLanguage;
            localStorage.setItem('selectedLanguage', selectedLanguage);
            window.location.href = this.href;
        });
    });
});
