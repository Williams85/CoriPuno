$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");

    $("#btn-consolidado-carguio").click(function () {
        var parametros = {
            "Fecha": $("#Fecha").val(),
        };
        Buscar(parametros);
        return false;
    });


});


function Buscar(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.BuscarConsolidadoCarguio;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdResultado").html(data);
        }
    });
}