$("#btnSaveBg").click(function () {
    var html = $("#invoiceBg").html();
    var head = $('head').append('<link rel="stylesheet" href="/css/pdf.css" />').html();

    var payload = "<!DOCTYPE html><html>" + head + "<body>" + html + "</body></html>";

    $("#html", "#pdfInvoiceBg").val(payload);
    $("#pdfInvoiceBg").submit();
});
// TODO Footer with github etc