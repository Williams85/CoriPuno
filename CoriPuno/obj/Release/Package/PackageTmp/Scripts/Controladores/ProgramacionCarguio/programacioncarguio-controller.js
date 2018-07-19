$(document).ready(function () {
    $("#IdCalcular").click(function () {

        $("#success_message").hide();
        $("#alert_message").hide();

        //Validar 
        var LeyMinima = $("#LeyMinima").val();
        var LeyMaxima = $("#LeyMaxima").val();
        var FEjecucion = $("#FEjecucion").val();

        var CantidadOrigen = $(this).attr("data-cantidadorigen");
        var CantidadDestino = $(this).attr("data-cantidaddestino");
        var ParametroOrigen = $(this).attr("data-parametroorigen");
        var ParametroDestino = $(this).attr("data-parametrodestino");

        var mensaje = "";
        if (CantidadOrigen != ParametroOrigen) {
            mensaje += "Número de labores Origen activas deben ser " + ParametroDestino +  "<br/>";
        }
        if (CantidadDestino != ParametroDestino) {
            mensaje += "Número de labores destino activas deben ser " + ParametroDestino + "<br/>";
        }

        if (mensaje != "") {
            $("#alert_message").empty();
            $("#alert_message").append(mensaje);
            $("#alert_message").show();
            return false;
        }
        if ((LeyMinima == null || LeyMinima == "") || (LeyMaxima == null || LeyMaxima == "") || (FEjecucion == null || FEjecucion == "")) {
            $("#alert_message").empty();
            $("#alert_message").append('Ingresar todos los valores!');
            $("#alert_message").show();
            return false;
        }

        if (LeyMinima.match('^[0-9]+([.][0-9]+)?$') == null) {
            $("#alert_message").empty();
            $("#alert_message").append('Ley Mínima Incorrecta. Solo se debe ingresar numeros y/o decimales');
            $("#alert_message").show();
            return false;
        }

        if (LeyMaxima.match('^[0-9]+([.][0-9]+)?$') == null) {
            $("#alert_message").empty();
            $("#alert_message").append('Ley Máxima Incorrecta. Solo se debe ingresar numeros y/o decimales');
            $("#alert_message").show();
            return false;
        }

        if (LeyMaxima < LeyMinima) {
            $("#alert_message").empty();
            $("#alert_message").append('Ley Máxima debe ser mayor o igual a la Ley Mínima');
            $("#alert_message").show();
            return false;
        }

        var parametros = { "Turno": $("#Turno").val(), "LeyMinima": LeyMinima, "LeyMaxima": LeyMaxima, "FEjecucion": FEjecucion };
        CalcularProgramacion(parametros);
        return false;
    });

    $("#IdCerrar").click(function () {
        var parametros = { "Turno": $("#TurnoPrograma").val(), "Fecha": $("#FechaPrograma").val() };
        CerrarProgramacion(parametros);
        return false
    });
});

function CalcularProgramacion(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.CalcularProgramacion;
    info.parametros = parametros;
    $("#success_message").hide();
    $("#danger_message").hide();
    $("#alert_message").hide();

    ajaxPartialView(info, function (data) {
        if (data != "" && data != 'undefined') {
            $("#ListadoProgramacion").html(data);
            $("#success_message").show();
            $("#FechaPrograma").val(parametros.FEjecucion);
            $("#TurnoPrograma").val(parametros.Turno);
        } else {
            $("#alert_message").show();
        }

    }, Error);
}

function CerrarProgramacion(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.CerrarProgramacion;
    info.parametros = parametros;
    $("#success_message").hide();
    ajax(info, function (data) {
        if (data == true) {
            $("#success_message").empty();
            $("#success_message").append("Programa cerrado!");
            $("#success_message").show();
            $("#keywords").remove();
            $("#ListadoProgramacion .container").remove();

        }

    }, Error);
}
