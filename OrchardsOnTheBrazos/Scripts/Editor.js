$(document).ready(function () {
    $(".adminActions").hide();
    $(".on").click(function () {
        $(".adminActions").show();
    });

    $(".off").click(function () {
        $(".adminActions").hide();
    });
});
