$(document).ready(function () {
    Hidden("#Message-Error");
    Hidden("#Message-OK");

    $("#btn-cambio-clave").on("click", function () {
        var parametros = {
            "Pass_Usuario": $("#nuevopassword").val()
        };
        var claveactual = $("#claveactual").val();
        var passwordactual = $("#passwordactual").val();
        var passwordnuevo = $("#nuevopassword").val();
        var passwordnuevoconfirmado = $("#passwordnuevoconfirmado").val();

        var mensaje = "";
        if (passwordactual == "" || passwordactual == null)
            mensaje += Constantes.Message.FaltaClaveActual + Constantes.SaltoHtml;

        if (passwordnuevo == "" || passwordnuevo == null)
            mensaje += Constantes.Message.FaltaClaveNueva + Constantes.SaltoHtml;

        if (passwordnuevoconfirmado == "" || passwordnuevoconfirmado == null)
            mensaje += Constantes.Message.FaltaClaveNuevaConfirmada + Constantes.SaltoHtml;

        if (mensaje == "" || mensaje == null) {
            if (claveactual != passwordactual)
                mensaje += Constantes.Message.ErrorClaveActual + Constantes.SaltoHtml;

            if (passwordactual == passwordnuevo)
                mensaje += Constantes.Message.ErrorDifClaveActual + Constantes.SaltoHtml;

            if (passwordnuevoconfirmado != passwordnuevo)
                mensaje += Constantes.Message.ErrorIgualClaveNueva + Constantes.SaltoHtml;
        }


        if (mensaje != "") {
            MostrarMensajeError(mensaje);
            return false;
        }
        CambiarClave(parametros);
        return false;
    });

});



function CambiarClave(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.CambiarClave;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null) {
            if (data.Estado)
                MostrarMensajeOK(Constantes.Message.CambioClave);
            else
                MostrarMensajeError(Constantes.Message.NoCambioClave);
        }
        else
            MostrarMensajeError(Constantes.Message.NoCambioClave);
    });
}