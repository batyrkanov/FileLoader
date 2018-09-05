function checkPhotoPreview() {
    $(document).ready(function () {
        $("#fileBrowes").change(function () {
            var File = this.files;
            console.log(File);

            if (File && File[0]) {
                ReadImage(File[0]);
            }
        })
    })

    var ReadImage = function (file) {

        var reader = new FileReader;
        var image = new Image;
        var size = ~~(file.size);
        var type = file.type;
        console.log(reader);
        if (type != "image/jpeg" && type != "image/png" && type != "image/jpg") {
            ClearPreview();
            $('#myModal').modal('show');
            $('#MessageError').text('Необходимо выбрать файл с расширением ZIP, RAR, DOCX, XLSX!');
        }
        else {
            reader.readAsDataURL(file);
            reader.onload = function (_file) {

                image.src = _file.target.result;
                image.onload = function () {

                    $("#targetImg").attr('src', _file.target.result);

                    if (size > 100000000) {
                        ClearPreview();
                        $('#myModal').modal('show');
                        $('#MessageError').text('Размер загружаемого файла не должен превышать 100 МБ!');
                    }
                }
            }
        }
    }
}

function ClearPreview() {
    $("#fileBrowes").val('');
}