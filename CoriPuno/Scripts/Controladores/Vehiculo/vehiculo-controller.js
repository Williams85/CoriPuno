$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");

    $("#btn-buscar").click(function () {
        var parametros = {
            "Placa": $("#Placa").val(),
            "Marca": $("#Marca").val()
        };
        Buscar(parametros);
        return false;
    });

    $("#btn-grabar").click(function () {

        Hidden("#Message-Error");
        Hidden("#Message-OK");

        var parametros = {
            "Placa": $("#Placa").val(),
            "Tara": $("#Tara").val(),
            "Capacidad": $("#Capacidad").val(),
            "Contrata": $("#Contrata :selected").val(),
            "Marca": $("#Marca").val(),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Placa == "" || parametros.Placa == null)
            mensaje_error += Constantes.Message.FaltaPlaca + Constantes.SaltoHtml;

        if (parametros.Tara == "" || parametros.Tara == null || parametros.Tara == "0")
            mensaje_error += Constantes.Message.FaltaTara + Constantes.SaltoHtml;
        else {
            if (parametros.Tara.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorZona + Constantes.SaltoHtml;
        }

        if (parametros.Capacidad == "" || parametros.Capacidad == null || parametros.Capacidad == "0")
            mensaje_error += Constantes.Message.FaltaCapacidad + Constantes.SaltoHtml;
        else {
            if (parametros.Capacidad.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorCapacidad + Constantes.SaltoHtml;
        }

        if (parametros.Contrata == "" || parametros.Contrata == null || parametros.Contrata == "0")
            mensaje_error += Constantes.Message.FaltaContrata + Constantes.SaltoHtml;
        else {
            if (parametros.Contrata.match(Constantes.ExpresionRegular.SoloNumeros) == null)
                mensaje_error += Constantes.Message.ErrorCapacidad + Constantes.SaltoHtml;
        }

        if (parametros.Marca == "" || parametros.Marca == null || parametros.Marca == "0")
            mensaje_error += Constantes.Message.FaltaMarca + Constantes.SaltoHtml;
        else {
            if (parametros.Marca.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorMarca + Constantes.SaltoHtml;
        }

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
            "IdVehiculo": $("#IdVehiculo").val(),
            "Placa": $("#Placa").val(),
            "Tara": $("#Tara").val(),
            "Capacidad": $("#Capacidad").val(),
            "Contrata": $("#Contrata :selected").val(),
            "Marca": $("#Marca").val(),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Placa == "" || parametros.Placa == null)
            mensaje_error += Constantes.Message.FaltaPlaca + Constantes.SaltoHtml;

        if (parametros.Tara == "" || parametros.Tara == null || parametros.Tara == "0")
            mensaje_error += Constantes.Message.FaltaTara + Constantes.SaltoHtml;
        else {
            if (parametros.Tara.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorZona + Constantes.SaltoHtml;
        }

        if (parametros.Capacidad == "" || parametros.Capacidad == null || parametros.Capacidad == "0")
            mensaje_error += Constantes.Message.FaltaCapacidad + Constantes.SaltoHtml;
        else {
            if (parametros.Capacidad.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorCapacidad + Constantes.SaltoHtml;
        }

        if (parametros.Contrata == "" || parametros.Contrata == null || parametros.Contrata == "0")
            mensaje_error += Constantes.Message.FaltaContrata + Constantes.SaltoHtml;
        else {
            if (parametros.Contrata.match(Constantes.ExpresionRegular.SoloNumeros) == null)
                mensaje_error += Constantes.Message.ErrorCapacidad + Constantes.SaltoHtml;
        }

        if (parametros.Marca == "" || parametros.Marca == null || parametros.Marca == "0")
            mensaje_error += Constantes.Message.FaltaMarca + Constantes.SaltoHtml;
        else {
            if (parametros.Marca.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorMarca + Constantes.SaltoHtml;
        }

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
            MostrarMensajeOK("No se grabo el vehiculo...");
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
            MostrarMensajeOK("No se modifico el vehiculo...");
    });
}