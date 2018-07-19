$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");

    if ($("#Tipo").val() == 'OR') {
        $("#Ley").prop("disabled", false);
        $("#Capacidad").prop("disabled", true);
        $("#PorRoca").prop("disabled", false);
        $("#AReaManiObra").prop("disabled", false);
    }
    else if ($("#Tipo").val() == 'DE') {
        $("#Ley").prop("disabled", true);
        $("#Capacidad").prop("disabled", false);
        $("#PorRoca").prop("disabled", true);
        $("#AReaManiObra").prop("disabled", true);
    }

    $("#btn-buscar").click(function () {
        var parametros = {
            "Codigo": $("#Codigo").val(),
            "Descripcion": $("#Descripcion").val(),
            "Tipo": $("#Tipo").val(),
            "Estado": $("#Estado").val(),
        };
        BuscarLabor(parametros);
        return false;
    });

    $("#Tipo").change(function () {

        $("#Capacidad").val("0");
        $("#PorRoca").val("0");
        $("#AReaManiObra").val("0");

        if ($(this).val() == 'OR') {
            $("#Capacidad").prop("disabled", true);
            $("#PorRoca").prop("disabled", false);
            $("#AReaManiObra").prop("disabled", false);
        }
        else if ($(this).val() == 'DE') {
            $("#Capacidad").prop("disabled", false);
            $("#PorRoca").prop("disabled", true);
            $("#AReaManiObra").prop("disabled", true);
        }
    });

    $("#btn-grabar").click(function () {

        Hidden("#Message-Error");
        Hidden("#Message-OK");

        var parametros = {
            "Codigo": $.trim($("#Codigo").val()),
            "Descripcion": $("#Descripcion").val(),
            "Tipo": $("#Tipo").val(),
            "FechaLey": $("#FechaLey").val(),
            "Ley": $("#Ley").val(),
            "Capacidad": $("#Capacidad").val(),
            "PorRoca": $("#PorRoca").val(),
            "AReaManiObra": $("#AReaManiObra").val(),
            "FechaApertura": $("#FechaApertura").val(),
            "Id_Mina": $("#Id_Mina").val(),
            "Id_Area": $("#Id_Area").val(),
            "Id_Zona": $("#Id_Zona").val(),
        };

        //Validar Datos
        var mensaje_error = "";

        if (parametros.Codigo == "" || parametros.Codigo == null)
            mensaje_error += Constantes.Message.FaltaCodigoLabor + Constantes.SaltoHtml;
        else {
            if (parametros.Codigo.match(Constantes.ExpresionRegular.SoloLetras) == null)
                mensaje_error += Constantes.Message.ErrorCodigoLabor + Constantes.SaltoHtml;
        }

        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaDescripcionLabor + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorDescripcionLabor + Constantes.SaltoHtml;
        }

        if (parametros.Tipo == "" || parametros.Tipo == null)
            mensaje_error += Constantes.Message.FaltaTipoLabor + Constantes.SaltoHtml;


        if (parametros.Ley == "" || parametros.Ley == null)
            mensaje_error += Constantes.Message.FaltaLeyLabor + Constantes.SaltoHtml;
        else {
            if (parametros.Ley.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorLeyLabor + Constantes.SaltoHtml;
        }
        if (parametros.Tipo == "DE") {
            if (parametros.Capacidad == "" || parametros.Capacidad == null)
                mensaje_error += Constantes.Message.FaltaCapMaximaLabor + Constantes.SaltoHtml;
            else {
                if (parametros.Capacidad.match(Constantes.ExpresionRegular.Precio) == null)
                    mensaje_error += Constantes.Message.ErrorCapMaximaLabor + Constantes.SaltoHtml;
            }
        } else {
            parametros.Capacidad = 0;
        }

        if (parametros.Tipo == "OR") {
            if (parametros.PorRoca == "" || parametros.PorRoca == null)
                mensaje_error += Constantes.Message.FaltaPorRocaLabor + Constantes.SaltoHtml;
            else {
                if (parametros.PorRoca.match(Constantes.ExpresionRegular.Precio) == null)
                    mensaje_error += Constantes.Message.ErrorPorRocaLabor + Constantes.SaltoHtml;
            }
        } else {
            parametros.PorRoca = 0;
        }

        if (parametros.Tipo == "OR") {
            if (parametros.AReaManiObra == "" || parametros.AReaManiObra == null)
                mensaje_error += Constantes.Message.FaltaAreaManoObraLabor + Constantes.SaltoHtml;
            else {
                if (parametros.AReaManiObra.match(Constantes.ExpresionRegular.Precio) == null)
                    mensaje_error += Constantes.Message.ErrorAreaManoObraLabor + Constantes.SaltoHtml;
            }
        } else {
            parametros.AReaManiObra = 0;
        }


        if (parametros.FechaApertura == "" || parametros.FechaApertura == null)
            mensaje_error += Constantes.Message.FaltaFechaAperturaLabor + Constantes.SaltoHtml;

        if (parametros.FechaLey == "" || parametros.FechaLey == null)
            mensaje_error += Constantes.Message.FaltaFechaLeyLabor + Constantes.SaltoHtml;

        if (parametros.Id_Mina == "" || parametros.Id_Mina == null)
            mensaje_error += Constantes.Message.FaltaMinaLabor + Constantes.SaltoHtml;

        if (parametros.Id_Area == "" || parametros.Id_Area == null)
            mensaje_error += Constantes.Message.FaltaAreaLabor + Constantes.SaltoHtml;

        if (parametros.Id_Zona == "" || parametros.Id_Zona == null)
            mensaje_error += Constantes.Message.FaltaZonaLabor + Constantes.SaltoHtml;


        if (mensaje_error != "") {
            MostrarMensajeError(mensaje_error);
            return false;
        }

        Hidden("#Message-Error");

        GrabarLabor(parametros);
        return false;
    });

    $("#btn-modificar").click(function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var parametros = {
            "Codigo": $.trim($("#Codigo").val()),
            "Codigo_A": $("#Codigo_A").val(),
            "Descripcion": $("#Descripcion").val(),
            "Tipo": $("#Tipo").val(),
            "FechaLey": $("#FechaLey").val(),
            "Ley": $("#Ley").val(),
            "Ley_A": $("#Ley_A").val(),
            "Capacidad": $("#Capacidad").val(),
            "PorRoca": $("#PorRoca").val(),
            "AReaManiObra": $("#AReaManiObra").val(),
            "FechaApertura": $("#FechaApertura").val(),
            "Id_Mina": $("#Id_Mina").val(),
            "Id_Area": $("#Id_Area").val(),
            "Id_Zona": $("#Id_Zona").val(),
        };

        //Validar Datos
        var mensaje_error = "";

        if (parametros.Codigo == "" || parametros.Codigo == null)
            mensaje_error += Constantes.Message.FaltaCodigoLabor + Constantes.SaltoHtml;
        else {
            if (parametros.Codigo.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorCodigoLabor + Constantes.SaltoHtml;
        }

        if (parametros.Descripcion == "" || parametros.Descripcion == null)
            mensaje_error += Constantes.Message.FaltaDescripcionLabor + Constantes.SaltoHtml;
        else {
            if (parametros.Descripcion.match(Constantes.ExpresionRegular.NumerosLetras) == null)
                mensaje_error += Constantes.Message.ErrorDescripcionLabor + Constantes.SaltoHtml;
        }

        if (parametros.Tipo == "" || parametros.Tipo == null)
            mensaje_error += Constantes.Message.FaltaTipoLabor + Constantes.SaltoHtml;


        if (parametros.Ley == "" || parametros.Ley == null)
            mensaje_error += Constantes.Message.FaltaLeyLabor + Constantes.SaltoHtml;
        else {
            if (parametros.Ley.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorLeyLabor + Constantes.SaltoHtml;
        }

        if (parametros.Capacidad == "" || parametros.Capacidad == null)
            mensaje_error += Constantes.Message.FaltaCapMaximaLabor + Constantes.SaltoHtml;
        else {
            if (parametros.Capacidad.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorCapMaximaLabor + Constantes.SaltoHtml;
        }

        if (parametros.PorRoca == "" || parametros.PorRoca == null)
            mensaje_error += Constantes.Message.FaltaPorRocaLabor + Constantes.SaltoHtml;
        else {
            if (parametros.PorRoca.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorPorRocaLabor + Constantes.SaltoHtml;
        }

        if (parametros.AReaManiObra == "" || parametros.AReaManiObra == null)
            mensaje_error += Constantes.Message.FaltaAreaManoObraLabor + Constantes.SaltoHtml;
        else {
            if (parametros.AReaManiObra.match(Constantes.ExpresionRegular.Precio) == null)
                mensaje_error += Constantes.Message.ErrorAreaManoObraLabor + Constantes.SaltoHtml;
        }

        if (parametros.FechaApertura == "" || parametros.FechaApertura == null)
            mensaje_error += Constantes.Message.FaltaFechaAperturaLabor + Constantes.SaltoHtml;

        if (parametros.FechaLey == "" || parametros.FechaLey == null)
            mensaje_error += Constantes.Message.FaltaFechaLeyLabor + Constantes.SaltoHtml;

        if (parametros.Id_Mina == "" || parametros.Id_Mina == null)
            mensaje_error += Constantes.Message.FaltaMinaLabor + Constantes.SaltoHtml;

        if (parametros.Id_Area == "" || parametros.Id_Area == null)
            mensaje_error += Constantes.Message.FaltaAreaLabor + Constantes.SaltoHtml;

        if (parametros.Id_Zona == "" || parametros.Id_Zona == null)
            mensaje_error += Constantes.Message.FaltaZonaLabor + Constantes.SaltoHtml;

        if (mensaje_error != "") {
            MostrarMensajeError(mensaje_error);
            return false;
        }

        Hidden("#Message-Error");

        ModificarLabor(parametros);
        return false;
    });

    $("#Id_Mina").change(function () {
        var parametros = {
            "Id_Mina": $.trim($(this).val()),
        };

        ListarAreas(parametros);
        return false;
    });

    $("#Id_Area").change(function () {
        var parametros = {
            "Id_Area": $.trim($(this).val()),
            "Id_Mina": $.trim($("#Id_Mina").val()),
        };

        ListarZonas(parametros);
        return false;
    });





});


function BuscarLabor(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.BuscarLabor;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdResultado").html(data);
            MostrarTotalOrigen();
            MostrarTotalDestino();

            $(".btn-cerrar").click(function () {
                var parametros = {
                    "Codigo": $(this).attr("data-labor"),
                }
                CerrarLabor(parametros);
                return false;
            });

            $(".btn-abrir").click(function () {
                var parametros = {
                    "Codigo": $(this).attr("data-labor"),
                    "Tipo": $(this).attr("data-tipo"),
                    "Ley": $(this).attr("data-ley"),
                    "Capacidad": $(this).attr("data-capacidad"),
                    "TotalOrigen": $(this).attr("data-cantidadorigen"),
                    "TotalDestino": $(this).attr("data-cantidaddestino"),
                }

                //Validacion
                if (parametros.Tipo == "OR") {
                    if (parametros.Ley == null || parametros.Ley == "" || parametros.Ley == "0") {
                        PopInformativo("La labor de tipo origen no tiene registrado ley...");
                        return false;
                    }

                    if (parametros.TotalOrigen > 10) {
                        PopInformativo("La labor de tipo origen no puede exceder las 10 unidades...");
                        return false;
                    }
                }
                else if (parametros.Tipo == "DE") {
                    if (parametros.Capacidad == null || parametros.Capacidad == "" || parametros.Capacidad == "0") {
                        PopInformativo("La labor de tipo destino no tiene registrado capacidad...");
                        return false;
                    }
                    if (parametros.TotalDestino > 5) {
                        PopInformativo("La labor de tipo destino no puede exceder las 5 unidades...");
                        return false;
                    }
                }
                AbrirLabor(parametros);
                return false;
            });

        }
    });
}


function MostrarTotalOrigen() {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.MostrarTotalOrigen;
    info.parametros = {};

    ajax(info, function (data) {
        if (data != null) {
            $("#TotalOrigen").val(data);
        }
    });
}

function MostrarTotalDestino() {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.MostrarTotalDestino;
    info.parametros = {};

    ajax(info, function (data) {
        if (data != null) {
            $("#TotalDestino").val(data);
        }
    });
}

function CerrarLabor(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.CerrarLabor;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null && data.Estado) {
            PopInformativo(data.Message);
            var parametros = {
                "Codigo": $("#Codigo").val(),
                "Descripcion": $("#Descripcion").val(),
                "Tipo": $("#Tipo").val(),
                "Estado": $("#Estado").val(),
            };
            BuscarLabor(parametros);
        }
    });
}

function AbrirLabor(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.AbrirLabor;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null && data.Estado) {
            PopInformativo(data.Message);
            var parametros = {
                "Codigo": $("#Codigo").val(),
                "Descripcion": $("#Descripcion").val(),
                "Tipo": $("#Tipo").val(),
                "Estado": $("#Estado").val(),
            };
            BuscarLabor(parametros);
        }
    });
}

function GrabarLabor(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.GrabarLabor;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null && data.Message != "" && data.Message != null)
            MostrarMensajeOK(data.Message);
        else
            MostrarMensajeOK("No se grabo la labor...");
    });
}

function ModificarLabor(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ModificarLabor;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null && data.Message != "" && data.Message != null)
            MostrarMensajeOK(data.Message);
        else
            MostrarMensajeOK("No se modifico la labor...");
    });
}

function ListarAreas(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarAreas;
    info.parametros = parametros;

    ajax(info, function (data) {
        CargarAreas(data, "#Id_Area");
    });
}

function CargarAreas(data, objeto) {
    $(objeto + ' option').remove();
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
        CargarZonas(data, "#Id_Zona");
    });
}

function CargarZonas(data, objeto) {
    $(objeto + ' option').remove();
    $.each(data, function (i, item) {
        $(objeto).append("<option value='"
           + item.Id_Zona + "'>" + item.Descripcion
           + "</option>");
    });
    $("#Id_Zona").trigger("change");

}

