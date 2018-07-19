$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");


    $("#btn-buscar").click(function () {
        var parametros = {
            "IdOrigen": $("#IdOrigen").val(),
            "IdDestino": $("#IdDestino").val(),
        };
        BuscarRutas(parametros);
        return false;
    });


    $("#btn-modificar").click(function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var parametros = {
            "IdRuta": $("#IdRuta").val(),
            "Distancia": $("#Distancia").val(),
            "Factor": $("#Factor").val(),
        };

        //Validar Datos
        var mensaje_error = "";

        if (parametros.Distancia == "" || parametros.Distancia == null)
            mensaje_error += Constantes.Message.FaltaDistanciaRuta + Constantes.SaltoHtml;
        else {
            if (parametros.Distancia.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorDistanciaRuta+ Constantes.SaltoHtml;
        }

        if (parametros.Factor == "" || parametros.Factor == null)
            mensaje_error += Constantes.Message.FaltaFactorRuta + Constantes.SaltoHtml;
        else {
            if (parametros.Factor.match(Constantes.ExpresionRegular.SoloNumeros) == null)
                mensaje_error += Constantes.Message.ErrorFactorRuta + Constantes.SaltoHtml;
        }


        if (mensaje_error != "") {
            MostrarMensajeError(mensaje_error);
            return false;
        }

        Hidden("#Message-Error");

        ModificarRuta(parametros);
        return false;
    });

});


function BuscarRutas(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.BuscarRutas;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdResultado").html(data);
        }
    });
}

function ModificarRuta(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ModificarRutas;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null && data.Message != "" && data.Message != null)
            MostrarMensajeOK(data.Message);
        else
            MostrarMensajeOK("No se modifico la ruta...");
    });
}

