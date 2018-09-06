function ClearPreview() {
    $("#fileBrowes").val('');
}
function CorrectExtension() {
    $('#myModal').modal('show');
    $('#MessageError').text('Необходимо выбрать файл только с расширением *.zip, *.rar, *.doc, *.docx, *.xls, *.xlsx, *.arj');
}
function SizeOverflow() {
    $('#myModal').modal('show');
    $('#MessageError').text('Общий размер загружаемых файлов не должен превышать 100 МБ, уменьшите размер и повторите заново загрузку файлов!');
}
function UploadSuccess() {
    $('#myModal').modal('show');
    $('#exampleModalLabel').text('Выполнено');
    $('#MessageError').text('Файлы успешно загружены!');
}

function deleteAllFiles() {
    var response = true;
    
    $.ajax({
        url: "/Home/Contact",
        type: "POST",
        data: {
            "response": response
        },
        cache: false,
        success: function (result) {
            $('#myModal').modal('show');
            $('#exampleModalLabel').text('Выполнено');
            $('#MessageError').text('Файлы успешно удалены!');
        },
        error: function (XMLHttpRequest) {
            console.log(XMLHttpRequest);
        }
    });
    return false;
}