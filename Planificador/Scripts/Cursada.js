


$(function () {
    $('#btnObtenerMateriasPendientes').click(function (e) {
        var names = $('#txtNombreAlumno').val();
        $.ajax({
            method: "POST",
            url: '<%= Url.Action("ObtenerMateriasPendientes", "CursadaController") %>',
            data: { name: names },
            success: function (result) {
                $("#table").add(result);
            },
            error: function (xmlHttpRequest, textStatus, errorThrown) {
                alert("Status: " + textStatus);
                alert("Error: " + errorThrown);
            }
        });
    });
});