function previewFile(input, previewId) {
    var preview = document.getElementById(previewId);
    var file = input.files[0];

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