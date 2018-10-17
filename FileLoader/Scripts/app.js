//Take Count and Names files from server folder and show on WebPage
function takeInfoFromDirectory() {
    $(function () {
        $(document).ready(function () {
            var booksDiv = $("#booksDiv");
            $.ajax({
                cache: false,
                type: "GET",
                url: "/Home/CountFiles",
                data: '{}',
                contextType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    $("#txtName").text(data[0].result)

                    var result = "";
                    booksDiv.html('');
                    $.each(data[1].names, function (index, value) {
                        result += value + '<br/>'
                    });
                    booksDiv.html(result);
                },
                failure: function (response) {
                    alert(response);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        });
    });
}

function ClearPreview() {
    $("#fileBrowes").val('');
}

//Show Modal Messages if ViewBag in HomeController/About equal true
function CorrectExtension() {
    $('#myModal').modal('show');
    $('#MessageError').text('Необходимо выбрать файл только с расширением *.zip, *.rar, *.doc, *.docx, *.xls, *.xlsx, *.arj');
}
function SizeOverflow() {
    $('#myModal').modal('show');
    $('#MessageError').text('Общий размер загружаемых файлов не должен превышать 100 МБ, уменьшите размер и повторите заново загрузку файлов!');
}
function NoFile() {
    $('#myModal').modal('show');
    $('#MessageError').text('Необходимо выбрать загружаемые файлы!');
}
function UploadSuccess() {
    $('#myModal').modal({
        backdrop: 'static',
        keyboard: false
    });
    $('#processingModal').modal('hide');
    $('#exampleModalLabel').text('Выполнено');
    $('#MessageError').text('Файлы успешно загружены!');
}

function LoadFiles() {
    $('#processingModal').modal({
        backdrop: 'static',
        keyboard: false
    });
}
function reloadWindowLoadFiles() {
    window.location.replace("/Home/Index");
}

function ZipAllFiles() {
    $('#processingModal').modal({
        backdrop: 'static',
        keyboard: false
    });

    var response = true;

    $.ajax({
        url: "/Home/Contact",
        type: "POST",
        data: {
            "response": response
        },
        cache: false,
        success: function (result) {
            $('#processingModal').modal('hide');
            $('#resultModal').modal({
                backdrop: 'static',
                keyboard: false
            });
            $('#exampleModalLabel').text('Выполнено');
            $('#Message').text('Файлы успешно сформированы!');
        },
        error: function (XMLHttpRequest) {
            $('#processingModal').modal('hide');
            console.log(XMLHttpRequest);
        }
    });

    return false;
}
function reloadWindowZipFiles() {
    location.reload();
}