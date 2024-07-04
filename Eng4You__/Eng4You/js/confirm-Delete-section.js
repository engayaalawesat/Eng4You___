document.getElementById('confirmdeleteButton').addEventListener('click', function () {
    // Show SweetAlert
    Swal.fire({
        title: 'Deleted!',
        text: 'The section has been deleted successfully ✅💯',
        icon: 'success',
        showCancelButton: false,
        showConfirmButton: false,
        timer: 2910, // 2000 milliseconds = 2 seconds
    }).then(() => {
        // Submit the form to the Delete action
        $('#deleteForm').submit();

        // Delay before redirecting to ensure the form is submitted
        setTimeout(() => {
            var deleteUrl = '/AddMajorSections/Index';
            window.location.href = deleteUrl;
        }, 500); // 500 milliseconds delay
    });
});