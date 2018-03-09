$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");


    $("#btn-buscar").click(function () {
        var parametros = {
            "Descripcion": $("#Descripcion").val()
        };
        Buscar(parametros);
        return false;
    });

    $("#btn-grabar").click(function () {

        Hidden("#Message-Error");
        Hidden("#Message-OK");

        var parametros = {
            "Descripcion": $("#Descripcion").val(),
            "Fec_Inicio": $("#Fec_Inicio").val(),
            "Fec_Fin": $("#Fec_Fin").val(),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaMina + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorMina + Constantes.SaltoHtml;
        }

        if (parametros.Fec_Inicio == "" || parametros.Fec_Inicio == null)
            mensaje_error += Constantes.Message.FaltaFechaInicioMina + Constantes.SaltoHtml;

        if (parametros.Fec_Fin == "" || parametros.Fec_Fin == null)
            mensaje_error += Constantes.Message.FaltaFechaFinMina + Constantes.SaltoHtml;



        if (mensaje_error != "") {
            MostrarMensajeError(mensaje_error);
            return false;
        }

        Hidden("#Message-Error");

        Grabar(parametros);
        return false;
    });

    $("#btn-modificar").click(function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var parametros = {
            "Id_Mina": $.trim($("#Id_Mina").val()),
            "Descripcion": $("#Descripcion").val(),
            "Fec_Inicio": $("#Fec_Inicio").val(),
            "Fec_Fin": $("#Fec_Fin").val(),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaMina + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorMina + Constantes.SaltoHtml;
        }

        if (parametros.Fec_Inicio == "" || parametros.Fec_Inicio == null)
            mensaje_error += Constantes.Message.FaltaFechaInicioMina + Constantes.SaltoHtml;

        if (parametros.Fec_Fin == "" || parametros.Fec_Fin == null)
            mensaje_error += Constantes.Message.FaltaFechaFinMina + Constantes.SaltoHtml;

        if (mensaje_error != "") {
            MostrarMensajeError(mensaje_error);
            return false;
        }

        Hidden("#Message-Error");

        Modificar(parametros);
        return false;
    });

});


function Buscar(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.Buscar;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdResultado").html(data);
        }
    });
}

function Grabar(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.Grabar;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null && data.Message != "" && data.Message != null)
            MostrarMensajeOK(data.Message);
        else
            MostrarMensajeOK("No se grabo la mina...");
    });
}

function Modificar(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.Modificar;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null && data.Message != "" && data.Message != null)
            MostrarMensajeOK(data.Message);
        else
            MostrarMensajeOK("No se modifico la mina...");
    });
}
