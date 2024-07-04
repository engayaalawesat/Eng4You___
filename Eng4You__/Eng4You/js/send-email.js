const form = document.querySelector('form[data-type="contactform"]');

form.addEventListener('submit', function (e) {
    e.preventDefault();
    var params = {
        first_name: document.getElementById("first_name").value,
        last_name: document.getElementById("last_name").value,
        email: document.getElementById("email").value,
        subject: document.getElementById("subject").value,
        message: document.getElementById("message").value,
    };

    const serviceID = "service_8u47m9f";
    const templateID = "template_hsc8vgl";

    emailjs
        .send(serviceID, templateID, params)
        .then((res) => {
            document.getElementById("first_name").value = "";
            document.getElementById("last_name").value = "";
            document.getElementById("email").value = "";
            document.getElementById("subject").value = "";
            document.getElementById("message").value = "";

            // Determine the language from the URL
            const currentPath = window.location.pathname;
            console.log("Current path:", currentPath); // Log the current path to help with debugging
            let successMessage = "Your message has reached us successfully🎉✨";
            let successTitle = "Success!!";

            if (currentPath.includes("/Language/Arabic")) {
                successMessage = "لقد وصلت رسالتك إلينا بنجاح 🎉✨";
                successTitle = "نجاح!!";
            } else if (currentPath.includes("/Language/Turkish")) {
                successMessage = "Mesajınız bize başarıyla ulaştı🎉✨";
                successTitle = "Başarılı!!";
            }

            // Display the success message
            sweetAlert(successTitle, successMessage, "success");
            console.log(res);
        })
        .catch((err) => console.log(err));
});
