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

        var size = ~~(file.size);
        reader.onload = function (_file) {
            if (size > 100000000) {
                ClearPreview();
                $('#myModal').modal('show');
                $('#MessageError').text('Размер загружаемого файла не должен превышать 100 МБ!');
            }
        }
    }
}


function ClearPreview() {
    $("#fileBrowes").val('');
}

function CorrectExtension() {
    $('#myModal').modal('show');
    $('#MessageError').text('Необходимо выбрать файл с расширением *.zip, *.rar, *.docx, *.xlsx');
}
function SizeOverflow() {
    $('#myModal').modal('show');
    $('#MessageError').text('Размер загружаемого файла не должен превышать 100 МБ!');
}
function UploadSuccess() {
    $('#myModal').modal('show');
    $('#exampleModalLabel').text('Выполнено');
    $('#MessageError').text('Файлы успешно загружены!');
}
