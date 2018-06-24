$(document).ready(function () {
    $(".adminActions").hide();
    $(".info-box > p > span").hide();

    $(".on").click(function () {
        $(".adminActions").show();
        $(".info-box > p > span").show();

    });

    $(".off").click(function () {
        $(".adminActions").hide();
        $(".info-box > p > span").hide();
    });
});
