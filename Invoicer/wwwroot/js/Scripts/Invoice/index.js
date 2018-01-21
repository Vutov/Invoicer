$("#btnSaveBg").click(function () {
    var html = $("#invoiceBg").html();
    var head = $('head').clone().append('<link rel="stylesheet" href="/css/pdf.css" />').html();

    var payload = "<!DOCTYPE html><html>" + head + "<body>" + html + "</body></html>";

    $("#html", "#pdfInvoiceBg").val(payload);
    $("#pdfInvoiceBg").submit();
});
// TODO Footer with github etc

$("#btnSaveEn").click(function () {
    var html = $("#invoiceEn").html();
    var head = $('head').clone().append('<link rel="stylesheet" href="/css/pdf.css" />').html();
    var payload = "<!DOCTYPE html><html>" + head + "<body>" + html  +"</body></html>";

    $("#html", "#pdfInvoiceEn").val(payload);
    $("#pdfInvoiceEn").submit();
});
// TODO Footer with github etc

$('input.seemless-control').change(function (e) {
    $(this).attr("value", $(this).val());
});