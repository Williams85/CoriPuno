$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");

    $("#btn-buscar").click(function () {
        var parametros = {
            "Descripcion": $("#Descripcion").val(),
            "Sigla": $("#Sigla").val(),
            "UnidadMedida": $("#UndMedidad").val(),
        };
        Buscar(parametros);
        return false;
    });

    $("#btn-grabar").click(function () {

        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var fuente = $("#Fuente :selected").val();
        var parametros = {
            "Descripcion": $("#Descripcion").val(),
            "Sigla": $("#Sigla").val(),
            "UnidadMedida": $("#UndMedidad").val(),
            "Fuente": $("#Fuente :selected").text(),
            "Procedimiento": $("#Procedimiento").val(),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaComponente + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.SoloLetras) == null)
                mensaje_error += Constantes.Message.ErrorComponente + Constantes.SaltoHtml;
        }

        if (parametros.Sigla == "" || parametros.Sigla == null)
            mensaje_error += Constantes.Message.FaltaSigla + Constantes.SaltoHtml;
        else {
            if (parametros.Sigla.match(Constantes.ExpresionRegular.SoloLetras) == null)
                mensaje_error += Constantes.Message.ErrorSigla + Constantes.SaltoHtml;
        }

        if (parametros.UnidadMedida == "" || parametros.UnidadMedida == null)
            mensaje_error += Constantes.Message.FaltaUndMedida + Constantes.SaltoHtml;
        else {
            if (parametros.UnidadMedida.match(Constantes.ExpresionRegular.SoloLetras) == null)
                mensaje_error += Constantes.Message.ErrorUndMedida + Constantes.SaltoHtml;
        }

        if (fuente == "2") {
            if (parametros.Procedimiento == "" || parametros.Procedimiento == null)
                mensaje_error += Constantes.Message.FaltaProcedimiento + Constantes.SaltoHtml;
            else {
                if (parametros.Procedimiento.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                    mensaje_error += Constantes.Message.ErrorProcedimiento + Constantes.SaltoHtml;
            }
        } else
            parametros.Procedimiento = "";


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
        var fuente = $("#Fuente :selected").val();
        var parametros = {
            "Id_Componente": $("#Id_Componente").val(),
            "Descripcion": $("#Descripcion").val(),
            "Sigla": $("#Sigla").val(),
            "UnidadMedida": $("#UnidadMedida").val(),
            "Fuente": $("#Fuente :selected").text(),
            "Procedimiento": $("#Procedimiento").val(),
            "Estado": $("#Estado :selected").val(),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaComponente + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.SoloLetras) == null)
                mensaje_error += Constantes.Message.ErrorComponente + Constantes.SaltoHtml;
        }

        if (parametros.Sigla == "" || parametros.Sigla == null)
            mensaje_error += Constantes.Message.FaltaSigla + Constantes.SaltoHtml;
        else {
            if (parametros.Sigla.match(Constantes.ExpresionRegular.SoloLetras) == null)
                mensaje_error += Constantes.Message.ErrorSigla + Constantes.SaltoHtml;
        }

        if (parametros.UnidadMedida == "" || parametros.UnidadMedida == null)
            mensaje_error += Constantes.Message.FaltaUndMedida + Constantes.SaltoHtml;
        else {
            if (parametros.UnidadMedida.match(Constantes.ExpresionRegular.SoloLetras) == null)
                mensaje_error += Constantes.Message.ErrorUndMedida + Constantes.SaltoHtml;
        }

        if (fuente == "2") {
            if (parametros.Procedimiento == "" || parametros.Procedimiento == null)
                mensaje_error += Constantes.Message.FaltaProcedimiento + Constantes.SaltoHtml;
            else {
                if (parametros.Procedimiento.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                    mensaje_error += Constantes.Message.ErrorProcedimiento + Constantes.SaltoHtml;
            }
        } else
            parametros.Procedimiento = "";

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
            MostrarMensajeOK("No se grabo el compoente...");
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
            MostrarMensajeOK("No se modifico el compoente...");
    });
}