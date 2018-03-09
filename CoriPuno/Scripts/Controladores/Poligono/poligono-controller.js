$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");

    $("#btn-buscar").click(function () {
        var parametros = {
            "Descripcion": $("#Descripcion").val(),
            "Mina": { "Id_Mina": ($("#Mina_Id_Mina").val() == "" ? "0" : $("#Mina_Id_Mina").val()) },
            "Area": { "Id_Area": ($("#Area_Id_Area").val() == "" ? "0" : $("#Area_Id_Area").val()) },
            "Zona": { "Id_Zona": ($("#Zona_Id_Zona").val() == "" ? "0" : $("#Zona_Id_Zona").val()) }
        };
        Buscar(parametros);
        return false;
    });

    $("#btn-grabar").click(function () {

        Hidden("#Message-Error");
        Hidden("#Message-OK");

        var parametros = {
            "Descripcion": $("#Descripcion").val(),
            "Mina": { "Id_Mina": ($("#Mina_Id_Mina").val() == "" ? "0" : $("#Mina_Id_Mina").val()) },
            "Area": { "Id_Area": ($("#Area_Id_Area").val() == "" ? "0" : $("#Area_Id_Area").val()) },
            "Zona": { "Id_Zona": ($("#Zona_Id_Zona").val() == "" ? "0" : $("#Zona_Id_Zona").val()) },
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaPoligono + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorPoligono + Constantes.SaltoHtml;
        }

        if (parametros.Mina.Id_Mina == "" || parametros.Mina.Id_Mina == null || parametros.Mina.Id_Mina == "0")
            mensaje_error += Constantes.Message.FaltaMinaPoligono + Constantes.SaltoHtml;

        if (parametros.Area.Id_Area == "" || parametros.Area.Id_Area == null || parametros.Area.Id_Area == "0")
            mensaje_error += Constantes.Message.FaltaAreaPoligono + Constantes.SaltoHtml;

        if (parametros.Zona.Id_Zona == "" || parametros.Zona.Id_Zona == null || parametros.Zona.Id_Zona == "0")
            mensaje_error += Constantes.Message.FaltaZonaPoligono + Constantes.SaltoHtml;


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
            "Id_Poligono": $("#Id_Poligono").val(),
            "Descripcion": $("#Descripcion").val(),
            "Mina": { "Id_Mina": ($("#Mina_Id_Mina").val() == "" ? "0" : $("#Mina_Id_Mina").val()) },
            "Area": { "Id_Area": ($("#Area_Id_Area").val() == "" ? "0" : $("#Area_Id_Area").val()) },
            "Zona": { "Id_Zona": ($("#Zona_Id_Zona").val() == "" ? "0" : $("#Zona_Id_Zona").val()) },
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaPoligono + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorPoligono + Constantes.SaltoHtml;
        }

        if (parametros.Mina.Id_Mina == "" || parametros.Mina.Id_Mina == null || parametros.Mina.Id_Mina == "0")
            mensaje_error += Constantes.Message.FaltaMinaPoligono + Constantes.SaltoHtml;

        if (parametros.Area.Id_Area == "" || parametros.Area.Id_Area == null || parametros.Area.Id_Area == "0")
            mensaje_error += Constantes.Message.FaltaAreaPoligono + Constantes.SaltoHtml;

        if (parametros.Zona.Id_Zona == "" || parametros.Zona.Id_Zona == null || parametros.Zona.Id_Zona == "0")
            mensaje_error += Constantes.Message.FaltaZonaPoligono + Constantes.SaltoHtml;


        if (mensaje_error != "") {
            MostrarMensajeError(mensaje_error);
            return false;
        }

        Hidden("#Message-Error");

        Modificar(parametros);
        return false;
    });

    $("#Mina_Id_Mina").change(function () {
        var parametros = {
            "Id_Mina": $.trim($(this).val()),
        };

        ListarAreas(parametros);
        return false;
    });

    $("#Area_Id_Area").change(function () {
        var parametros = {
            "Id_Area": $.trim($(this).val()),
            "Mina": { "Id_Mina": $.trim($("#Mina_Id_Mina").val()) },
        };

        ListarZonas(parametros);
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
            MostrarMensajeOK("No se grabo el poligono...");
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
            MostrarMensajeOK("No se modifico el poligono...");
    });
}

function ListarAreas(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarAreas;
    info.parametros = parametros;

    ajax(info, function (data) {
        CargarAreas(data, "#Area_Id_Area");
    });
}

function CargarAreas(data, objeto) {
    $(objeto + ' option').remove();
    $(objeto).append("<option value='0'>Seleccionar</option>");
    $.each(data, function (i, item) {
        $(objeto).append("<option value='"
           + item.Id_Area + "'>" + item.Descripcion
           + "</option>");
    });
    $("#Id_Area").trigger("change");

}

function ListarZonas(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarZonas;
    info.parametros = parametros;

    ajax(info, function (data) {
        CargarZonas(data, "#Zona_Id_Zona");
    });
}

function CargarZonas(data, objeto) {
    $(objeto + ' option').remove();
    $(objeto).append("<option value='0'>Seleccionar</option>");
    $.each(data, function (i, item) {
        $(objeto).append("<option value='"
           + item.Id_Zona + "'>" + item.Descripcion
           + "</option>");
    });
    $("#Zona_Id_Zona").trigger("change");

}