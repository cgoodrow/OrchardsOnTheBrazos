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

function DeleteDownload(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/Supports/DownloadModal/' + id,
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

function EditAnnouncements(id) {
    if (!ValidateInputs())
        return;
    $.ajax({
        url: '/Announcements/Edit/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["Id", "Title", "Date", "Announcement"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            })
            console.log("modal");
            $(".close").click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};

function DeleteAnnouncements(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/Announcements/Delete/' + id,
        data: $('form').serialize(),
        type: 'POST',
        success: function () { $('#close').click(); },
        error: function (err) { alert("Error: " + err.responseText); }
    });
};

function DetailsAnnouncements(id) {
    if (!ValidateInputs())
        return;
    $.ajax({
        url: '/Announcements/Details/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["Id", "Title", "Date", "Announcement"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            })
            console.log("modal");
            $(".close").click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};

function EditEvents(id) {
    if (!ValidateInputs())
        return;
    $.ajax({
        url: '/Events/Edit/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["EventId", "EventPost", "EventPicture"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            })
            console.log("modal");
            $(".close").click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};

function DetailsEvents(id) {
    if (!ValidateInputs())
        return;
    $.ajax({
        url: '/Events/Details/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["EventId", "EventPost", "EventPicture"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            })
            console.log("modal");
            $(".close").click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};

function DeleteEvent(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/Events/Delete/' + id,
        data: $('form').serialize(),
        type: 'POST',
        success: function () { $('.close').click(); },
        error: function (err) { alert("Error: " + err.responseText); }
    });
};

function DeleteInfo(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/Info/Delete/' + id,
        data: $('form').serialize(),
        type: 'POST',
        success: function () { $('.close').click(); },
        error: function (err) { alert("Error: " + err.responseText); }
    });
};

function DetailsInfo(id) {
    if (!ValidateInputs())
        return;
    $.ajax({
        url: '/Info/Details/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["Id", "Site", "Link"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            })
            console.log("modal");
            $(".close").click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};

function EditInfo(id) {
    if (!ValidateInputs())
        return;
    $.ajax({
        url: '/Info/Edit/' + id,
        type: 'POST',
        data: $('form').serialize(),
        success: function (res) {
            var keys = ["Id", "Site", "Link"];
            $('#' + res.Id + ' td').each(function (i) {
                $(this).text(res[keys[i]]);
            })
            console.log("modal");
            $(".close").click();
        },
        error: function (err) { alert("Error: " + err.responseText); }
    })
};

function DeleteDirectory(id) {
    document.getElementById(id).remove();
    $.ajax({
        url: '/Directory/Delete/' + id,
        data: $('form').serialize(),
        type: 'POST',
        success: function () { $('#close').click(); },
        error: function (err) { alert("Error: " + err.responseText); }
    });
};