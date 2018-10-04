$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");
    //$(".oper-formula").each(function (index, element) {
    //    $(element).val("");
    //});

    $("#btn-agregar-componente").on("click", function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var elemento = $("#Id_Componente").val();
        if (elemento == null || elemento == "") {
            MostrarMensajeError("Se debe seleccionar el componente");
            return false;
        }
        $(".oper-formula").each(function (index, element) {
            if ($(element).val() == null || $(element).val() == "") {
                $(element).val(elemento);
                return false;
            }
        });
    });

    $("#btn-agregar-operador").on("click", function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var elemento = $("#Id_Operador option:selected").val();
        if (elemento == null || elemento == "") {
            MostrarMensajeError("Se debe seleccionar el operador");
            return false;
        }
        $(".oper-formula").each(function (index, element) {
            if ($(element).val() == null || $(element).val() == "") {
                $(element).val(elemento);
                return false;
            }
        });
    });

    $("#btn-agregar-agrupador").on("click", function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var elemento = $("#Id_Agrupador option:selected").val();
        if (elemento == null || elemento == "") {
            MostrarMensajeError("Se debe seleccionar el agrupador");
            return false;
        }
        $(".oper-formula").each(function (index, element) {
            if ($(element).val() == null || $(element).val() == "") {
                $(element).val(elemento);
                return false;
            }
        });
    });

    $("#btn-delete-nuevo").on("click", function () {
        $(".oper-formula").each(function (index, element) {
            $(element).val("");
        });
    });

    $("#btn-delete-edit").on("click", function () {
        $(".oper-formula").each(function (index, element) {
            $(element).val("");
        });
    });

    $("#btn-buscar").click(function () {
        var parametros = {
            "Nom_Indicador": $("#Nom_Indicador").val()
        };
        Buscar(parametros);
        return false;
    });

    $("#btn-grabar").click(function () {

        Hidden("#Message-Error");
        Hidden("#Message-OK");

        var parametros = {
            "Nom_Indicador": $("#Nom_Indicador").val(),
            "Var_Indicador": $("#Var_Indicador").val(),
            "Ope_1": $("#Ope_1").val(),
            "Ope_2": $("#Ope_2").val(),
            "Ope_3": $("#Ope_3").val(),
            "Ope_4": $("#Ope_4").val(),
            "Ope_5": $("#Ope_5").val(),
            "Ope_6": $("#Ope_6").val(),
            "Ope_7": $("#Ope_7").val(),
            "Ope_8": $("#Ope_8").val(),
            "Ope_9": $("#Ope_9").val(),
            "Ope_10": $("#Ope_10").val(),
            "Ope_11": $("#Ope_11").val(),
            "Ope_12": $("#Ope_12").val(),
            "Ope_13": $("#Ope_13").val(),
            "Ope_14": $("#Ope_14").val(),
            "Ope_15": $("#Ope_15").val(),
            "Ope_16": $("#Ope_16").val(),
            "Ope_17": $("#Ope_17").val(),
            "Ope_18": $("#Ope_18").val(),

        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Nom_Indicador == "" || parametros.Nom_Indicador == null)
            mensaje_error += Constantes.Message.FaltaNomIndicador + Constantes.SaltoHtml;

        if (parametros.Var_Indicador == "" || parametros.Var_Indicador == null)
            mensaje_error += Constantes.Message.FaltaVarIndicador + Constantes.SaltoHtml;

        if (parametros.Ope_1 == "" || parametros.Ope_1 == null)
            mensaje_error += Constantes.Message.FaltaFormula + Constantes.SaltoHtml;

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
            "Id_Indicador": $("#Id_Indicador").val(),
            "Nom_Indicador": $("#Nom_Indicador").val(),
            "Var_Indicador": $("#Var_Indicador").val(),
            "Ope_1": $("#Ope_1").val(),
            "Ope_2": $("#Ope_2").val(),
            "Ope_3": $("#Ope_3").val(),
            "Ope_4": $("#Ope_4").val(),
            "Ope_5": $("#Ope_5").val(),
            "Ope_6": $("#Ope_6").val(),
            "Ope_7": $("#Ope_7").val(),
            "Ope_8": $("#Ope_8").val(),
            "Ope_9": $("#Ope_9").val(),
            "Ope_10": $("#Ope_10").val(),
            "Ope_11": $("#Ope_11").val(),
            "Ope_12": $("#Ope_12").val(),
            "Ope_13": $("#Ope_13").val(),
            "Ope_14": $("#Ope_14").val(),
            "Ope_15": $("#Ope_15").val(),
            "Ope_16": $("#Ope_16").val(),
            "Ope_17": $("#Ope_17").val(),
            "Ope_18": $("#Ope_18").val(),

        };

        //Validar Datos
        var mensaje_error = "";


        if (parametros.Nom_Indicador == "" || parametros.Nom_Indicador == null)
            mensaje_error += Constantes.Message.FaltaNomIndicador + Constantes.SaltoHtml;

        if (parametros.Var_Indicador == "" || parametros.Var_Indicador == null)
            mensaje_error += Constantes.Message.FaltaVarIndicador + Constantes.SaltoHtml;

        if (parametros.Ope_1 == "" || parametros.Ope_1 == null)
            mensaje_error += Constantes.Message.FaltaFormula + Constantes.SaltoHtml;

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
            MostrarMensajeOK("No se grabo la formulación de indicador...");
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
            MostrarMensajeOK("No se modifico la formulación de indicador...");
    });
}
