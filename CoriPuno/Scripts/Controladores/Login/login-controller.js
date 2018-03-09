$(document).ready(function () {

    Hidden("#Message-Error");
});

function ValidarLogin(obj) {
        var parametros = {
            Nom_Usuario: $("#Nom_Usuario").val(),
            Pass_Usuario: $("#Pass_Usuario").val(),
        };

        var mensaje = "";
        if (parametros.Nom_Usuario == null || parametros.Nom_Usuario == "")
            mensaje += Constantes.Message.FaltaUsuario + Constantes.SaltoHtml;

        if (parametros.Pass_Usuario == null || parametros.Pass_Usuario == "")
            mensaje += Constantes.Message.FaltaPassword + Constantes.SaltoHtml;

        if (mensaje != "") {
            MostrarMensajeError(mensaje);
            return false;
        }

        //Consultar Controlador
        var estado = false;
        var info = new Object();
        info.metodo = "POST";
        info.serviceURL = rutas.ValidarLogin;
        info.parametros = parametros;
        ajax(info, function (data) {
            console.log(data);
            if (data != null) {
                if (data.Estado == false) {
                    MostrarMensajeError(data.Message);
                    estado = false;
                } else {
                    document.forms['form01'].submit();
                }
            } else {
                MostrarMensajeError(Constantes.Message.ErrUserPass);
                estado = false;
            }
        }, function () {
            estado = false;
        });
        return false;
}