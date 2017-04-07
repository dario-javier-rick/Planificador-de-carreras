
$(function () {
    $('#btn').click(function (e) {
        var names = $('#input').val();
        $.ajax({
            method: "POST",
            url: '<%= Url.Action("GetMateriasPendientes", "CursadaController") %>',
            data: { name: names },
            success: function (result) {
                $("#table").add(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus); alert("Error: " + errorThrown);
            }
        }).done(function (msg) {
            alert("Yaaay done " + msg);
        }).fail(function () {
            alert("Oh no");
        });
    });
})