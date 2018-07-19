$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");

    $("#Fec_Inicio")
      .datepicker({
          defaultDate: new Date(),
          minDate: new Date(),
          changeMonth: true,
          changeYear: true,
          yearRange: "1900:2023",
          numberOfMonths: 1
      })

    $("#btn-buscar").click(function () {
        var parametros = {
            "Descripcion": $("#Descripcion").val(),
            "Mina": { "Id_Mina": ($("#Mina_Id_Mina").val() == "" ? "0" : $("#Mina_Id_Mina").val()) },
            "Area": { "Id_Area": ($("#Area_Id_Area").val() == "" ? "0" : $("#Area_Id_Area").val()) }
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
            "Fec_Inicio": $("#Fec_Inicio").val(),
            "Estado": ($("#Estado").prop("checked") == true ? "1" : "0"),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaZona + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorZona + Constantes.SaltoHtml;
        }

        if (parametros.Mina.Id_Mina == "" || parametros.Mina.Id_Mina == null || parametros.Mina.Id_Mina == "0")
            mensaje_error += Constantes.Message.FaltaMinaZona + Constantes.SaltoHtml;

        if (parametros.Area.Id_Area == "" || parametros.Area.Id_Area == null || parametros.Area.Id_Area == "0")
            mensaje_error += Constantes.Message.FaltaAreaZona + Constantes.SaltoHtml;

        if (parametros.Fec_Inicio == "" || parametros.Fec_Inicio == null || parametros.Fec_Inicio == "0")
            mensaje_error += Constantes.Message.FaltaFechaInicioZona + Constantes.SaltoHtml;


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
            "Id_Zona": $("#Id_Zona").val(),
            "Descripcion": $("#Descripcion").val(),
            "Mina": { "Id_Mina": ($("#Mina_Id_Mina").val() == "" ? "0" : $("#Mina_Id_Mina").val()) },
            "Area": { "Id_Area": ($("#Area_Id_Area").val() == "" ? "0" : $("#Area_Id_Area").val()) },
            "Fec_Inicio": $("#Fec_Inicio").val(),
            "Estado": ($("#Estado").prop("checked") == true ? "1" : "0"),
        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaZona + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorZona + Constantes.SaltoHtml;
        }

        if (parametros.Mina.Id_Mina == "" || parametros.Mina.Id_Mina == null || parametros.Mina.Id_Mina == "0")
            mensaje_error += Constantes.Message.FaltaMinaZona + Constantes.SaltoHtml;

        if (parametros.Area.Id_Area == "" || parametros.Area.Id_Area == null || parametros.Area.Id_Area == "0")
            mensaje_error += Constantes.Message.FaltaAreaZona + Constantes.SaltoHtml;

        if (parametros.Fec_Inicio == "" || parametros.Fec_Inicio == null || parametros.Fec_Inicio == "0")
            mensaje_error += Constantes.Message.FaltaFechaInicioZona + Constantes.SaltoHtml;

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
            MostrarMensajeOK("No se grabo la zona...");
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
            MostrarMensajeOK("No se modifico la zona...");
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