$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");


    $("#btn-buscar").click(function () {
        var parametros = {
            "Nom_Usuario": $("#Nom_Usuario").val(),
            "Perfil": { "Id_Perfil": ($("#Id_Perfil").val() == "" ? "" : $("#Id_Perfil").val()) }
        };
        Buscar(parametros);
        return false;
    });

    $("#btn-grabar").click(function () {

        Hidden("#Message-Error");
        Hidden("#Message-OK");

        var parametros = {
            "Nom_Usuario": $("#Nom_Usuario").val(),
            "Pass_Usuario": $("#Pass_Usuario").val(),
            "Perfil_Usuario": $("#Perfil_Usuario").val(),
            "Perfil": { "Id_Perfil": $("#Id_Perfil").val() },
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Nom_Usuario == "" || parametros.Nom_Usuario == null)
            mensaje_error += Constantes.Message.FaltaUsuario + Constantes.SaltoHtml;
        else {
            if (parametros.Nom_Usuario.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorUsuario + Constantes.SaltoHtml;
        }

        if (parametros.Pass_Usuario == "" || parametros.Pass_Usuario == null)
            mensaje_error += Constantes.Message.FaltaPassword + Constantes.SaltoHtml;

        if (parametros.Perfil_Usuario == "" || parametros.Perfil_Usuario == null)
            mensaje_error += Constantes.Message.FaltaPerfilUsuario + Constantes.SaltoHtml;
        else {
            if (parametros.Perfil_Usuario.match(Constantes.ExpresionRegular.NombresApellidos) == null)
                mensaje_error += Constantes.Message.ErrorPerfilUsuario + Constantes.SaltoHtml;
        }

        if (parametros.Perfil.Id_Perfil == "" || parametros.Perfil.Id_Perfil == null)
            mensaje_error += Constantes.Message.FaltaPerfilAcceso + Constantes.SaltoHtml;

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
            "Id_Usuario": $.trim($("#Id_Usuario").val()),
            "Nom_Usuario": $("#Nom_Usuario").val(),
            "Pass_Usuario": $("#Pass_Usuario").val(),
            "Perfil_Usuario": $("#Perfil_Usuario").val(),
            "Perfil": { "Id_Perfil": $("#Perfil_Id_Perfil").val() },
            "Activo": $("#Activo").prop("checked"),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Nom_Usuario == "" || parametros.Nom_Usuario == null)
            mensaje_error += Constantes.Message.FaltaUsuario + Constantes.SaltoHtml;
        else {
            if (parametros.Nom_Usuario.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorUsuario + Constantes.SaltoHtml;
        }
        
        if (parametros.Pass_Usuario == "" || parametros.Pass_Usuario == null)
            mensaje_error += Constantes.Message.FaltaPassword + Constantes.SaltoHtml;

        if (parametros.Perfil_Usuario == "" || parametros.Perfil_Usuario == null)
            mensaje_error += Constantes.Message.FaltaPerfilUsuario + Constantes.SaltoHtml;
        else {
            if (parametros.Perfil_Usuario.match(Constantes.ExpresionRegular.NombresApellidos) == null)
                mensaje_error += Constantes.Message.ErrorPerfilUsuario + Constantes.SaltoHtml;
        }

        if (parametros.Perfil.Id_Perfil == "" || parametros.Perfil.Id_Perfil == null)
            mensaje_error += Constantes.Message.FaltaPerfilAcceso + Constantes.SaltoHtml;

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
            MostrarMensajeOK("No se grabo el usuario...");
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
            MostrarMensajeOK("No se modifico el usuario...");
    });
}
