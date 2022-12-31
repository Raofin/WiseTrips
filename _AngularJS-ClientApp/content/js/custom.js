function getUser(id) {
    $.ajax({
        type: 'GET',
        url: 'https://localhost:44359/api/users/' + id,
        success: function (response) {
            console.log(response);
            return response;
        }
    });
}

/*
$(document).on("click", ".pdf-report", function () {
    $.ajax({
        url: "ReportService.asmx/PDFReportGenerate",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        type: "POST",
        success: function (response) {
            if (response.d.length > 0) {
                window.open(response.d[0].pdfReportPath);
            }
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
});*/
