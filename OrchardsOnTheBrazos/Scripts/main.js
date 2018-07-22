$(document).ready(function () {
    $.ajaxSetup({ cache: false });
});

function RenderActions(RenderActionstring) {
    $("#OpenDialog").load(RenderActionstring);
};

function DeleteSupport(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/Supports/Delete/' + id,
        data: $('form').serialize(),
        type: 'POST',
        success: function () { $('#close').click(); },
        error: function (err) { alert("Error: " + err.responseText); }
    });
};
    
function EditSupport(id) {
    if (!ValidateInputs())
        return;
    $.ajax({
        url: '/Supports/Edit/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["Id", "Name", "Summary", "FileDetail"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            })
            console.log("modal");
            $(".close").click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};
