function startDownloadTimer(fileName) {
    let timerInterval;
    let countdown = 10; 

    Swal.fire({
        title: 'Download will start in 10 minutes!',
        html: 'Time remaining: <strong></strong> seconds.',
        timer: 600000, 
        timerProgressBar: true,
        didOpen: () => {
            Swal.showLoading();

            const strong = Swal.getHtmlContainer().querySelector('strong');
            timerInterval = setInterval(() => {
                countdown--;
                strong.textContent = countdown;

                if (countdown <= 0) {
                    clearInterval(timerInterval);

                    // Fetch the file without navigating away
                    fetch('@Url.Action("DownloadFile", "Programmes")?fileName=' + encodeURIComponent(fileName))
                        .then(response => response.blob())
                        .then(blob => {
                            const link = document.createElement('a');
                            link.href = URL.createObjectURL(blob);
                            link.download = fileName;
                            document.body.appendChild(link);
                            link.click();
                            document.body.removeChild(link);
                            URL.revokeObjectURL(link.href);

                            Swal.fire({
                                icon: 'success',
                                title: 'Success',
                                text: 'The download has started successfully!'
                            });
                        })
                        .catch(error => {
                            Swal.fire({
                                icon: 'error',
                                title: 'Error',
                                text: 'There was a problem downloading the file. Please try again later.'
                            });
                        });
                }
            }, 1000);
        },
        willClose: () => {
            clearInterval(timerInterval);
        }
    });
}