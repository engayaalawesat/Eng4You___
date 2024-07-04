    $(document).ready(function () {
        $('form').on('submit', function (e) {
            e.preventDefault(); 

            var formData = new FormData(this);

            $.ajax({
                type: 'POST',
                url: $(this).attr('action'),
                data: formData,
                contentType: false,
                processData: false,
                success: function (response) {
                    // Handle the success response here
                    // You can redirect to another page or show a success message
                    window.location.href = '/All_Books/Index';
                },
                error: function (response) {
                    // Handle the error response here
                    alert('An error occurred. Please try again.');
                }
            });
        });
    });
