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
                        result +=  value + '<br/>'
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
    $('#myModal').modal('show');
    $('#exampleModalLabel').text('Выполнено');
    $('#MessageError').text('Файлы успешно загружены!');
}

function zipAllFiles() {
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
            $('#MessageError').text('Файлы успешно сформированы!');

            setTimeout(function () {          
                location.reload();
            }, 2000);           
        },
        error: function (XMLHttpRequest) {
            console.log(XMLHttpRequest);
        }
    });
    return false;
}