function previewFile() {
    var preview = document.getElementById('previewImage');
    var fileInput = document.getElementById('ImageFile');
    var file = fileInput.files[0];

    var reader = new FileReader();

    reader.onloadend = function () {
        preview.src = reader.result;
        preview.style.display = "block"; // Display the image
    };

    if (file) {
        reader.readAsDataURL(file);
    } else {
        preview.src = "";
        preview.style.display = "none"; // Hide the image
    }
}