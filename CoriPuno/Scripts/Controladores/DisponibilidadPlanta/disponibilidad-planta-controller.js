$(document).ready(function () {
    $("#IdActualizaConsolidado").on("click", function () {
        $("#alert_message").empty()
        $("#alert_message").hide();
        var estado = 0;
        var parametros = [];
        $(".item-stock").each(function (index, item) {
            if ($(this).prop("checked") == true) {
                var parametro = {
                    "Año": $(this).attr("data-año"),
                    "Mes": $(this).attr("data-mes"),
                    "Turno": $(this).attr("data-turno"),
                    "LaborOrigen": $(this).attr("data-labor-origen"),
                    "LaborDestino": $(this).attr("data-labor-destino"),
                };
                parametros.push(parametro);
                estado = 1;
            }
        });
        if (estado == 0) {
            $("#alert_message").append("Se debe seleccionar un item...");
            $("#alert_message").show();
        return false;
        }
        ActualizarStockDisponible(parametros);

    });
});

function ActualizarStockDisponible(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ActualizarStockDisponible;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdConsolidadoMaterial").html(data);
        }
    });
}