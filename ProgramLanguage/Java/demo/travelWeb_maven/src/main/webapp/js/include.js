$(function () {
    $.get("header.html",function (data) {
        $("#header").html(data);
    });
    $.get("footer.html",function (data) {
        $("#footer").html(data);
    });
    $.get("navItem.html", function (data) {
        $("#navitem").html(data);
    })
});