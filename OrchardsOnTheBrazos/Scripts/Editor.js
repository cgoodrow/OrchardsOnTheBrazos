$(document).ready(function () {
    // $(".adminActions").hide();
    $(".info-box > p > span").hide();

    $("#toggleSwitch").change(function () {
        var toggle = $('.toggle');
        var toggleClass = $(toggle).hasClass("off")
        if (toggleClass) {
            $(".adminActions").hide();
        }
        else {
            $(".adminActions").show();
        }
    });
});

