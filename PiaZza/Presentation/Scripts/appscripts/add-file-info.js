function previewFiles() {
    var preview = document.querySelector('#imagePreview');
    var files = document.querySelector('input[type=file]').files;
    function readAndPreview(file) {
        if (/\.(jpe?g|png|bmp)$/i.test(file.name)) {
            var reader = new FileReader();
            reader.addEventListener("load", function () {
                var image = new Image();
                image.height = 100;
                image.title = file.name;
                image.src = this.result;
                preview.appendChild(image);
            }, false);
            reader.readAsDataURL(file);
        }
    }
    if (files) {
        [].forEach.call(files, readAndPreview);
    }
}
$(document).ready(function () {
    $("#Image").change(previewFiles);
});