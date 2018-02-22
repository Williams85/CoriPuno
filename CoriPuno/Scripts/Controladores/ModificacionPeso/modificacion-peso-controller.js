$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");

    $("#Placa").change(function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");

        var parametros = {
            "Fecha": $("#Fecha").val(),
            "Placa": $("#Placa").val(),
        }
        var mensaje = "";
        if (parametros.Placa == null || parametros.Placa == "")
            mensaje += "Ingresar la placa.. <br/>";

        if (parametros.Fecha == null || parametros.Fecha == "")
            mensaje += "Ingresar la fecha... <br/>";

        if (mensaje != "") {
            MostrarMensajeError(mensaje);
            $("#IdDetalleLabores").empty();
            return false;
        }
        $("#ProgPlaca").val(parametros.Placa);
        $("#ProgFecha").val(parametros.Fecha);

        ListarLabores(parametros);
        return false;
    });
    
});



function ListarLabores(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarLabores;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdDetalleLabores").empty();
            $("#IdDetalleLabores").html(data);

            $("input:radio[name=seleccion-prog]").click(function () {
                Hidden("#Message-Error");
                Hidden("#Message-OK");

                var PesoNeto = $(this).attr("data-pesoneto");
                var Turno = $(this).attr("data-turno");
                var Labor = $(this).attr("data-labor");

                $("#ProgPesoNeto").val(PesoNeto);
                $("#ProgPesoNeto_A").val(PesoNeto);
                $("#ProgTurno").val(Turno);
                $("#ProgLabor").val(Labor);

                $("#DicePeso").val(PesoNeto);
                $("#DebeDecirPeso").val(PesoNeto);
                $("#DebeDecirPeso").attr("disabled", false);
                $("#btn-modificar").attr("disabled", false);
            });

            $("#btn-modificar").click(function () {
                Hidden("#Message-Error");
                Hidden("#Message-OK");
                var parametros = {
                    "Fecha": $("#ProgFecha").val(),
                    "Placa": $("#ProgPlaca").val(),
                    "Labor_or": $("#ProgLabor").val(),
                    "Turno": $("#ProgTurno").val(),
                    "PesoNeto": $("#DebeDecirPeso").val(),
                    "PesoNeto_A": $("#ProgPesoNeto_A").val(),
                    "Sustento": $("#Sustento").val(),
                    "Autoriza": $("#Autoriza").val(),
                }

                var mensaje = "";
                if (parametros.PesoNeto == null || parametros.PesoNeto == "")
                    mensaje = "Ingresar el peso nuevo... <br/>";

                if (parametros.Sustento == null || parametros.Sustento == "")
                    mensaje = "Ingresar el sustento de cambio... <br/>";

                if (parametros.Autoriza == null || parametros.Autoriza == "")
                    mensaje = "Ingresar la persona que autoriza el cambio... <br/>";

                if (mensaje != "") {
                    MostrarMensajeError(mensaje);
                    return false;
                }



                GrabarModificacioNPeso(parametros);
                return false;
            });

        }
    });
}


function GrabarModificacioNPeso(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.GrabarModificacioNPeso;
    info.parametros = parametros;
    ajax(info, function (data) {
        if (data != null) {
            PopInformativo(data.Message);
            $("#DebeDecirPeso").attr("disabled", true);
            $("#Sustento").val("");
            $("#Autoriza").val("");
            $("input:radio[name=seleccion-prog]").prop("checked", false);
            $("#DicePeso").val("");
            $("#DebeDecirPeso").val("");
            $("#btn-modificar").attr("disabled", true);
        }
    });
}


function ListarDetalleProgramacionPeso(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarDetalleProgramacionPeso;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {

        if (data != null) {
            $("#IdLaborOrigen").empty();
            $("#IdLaborOrigen").html(data);
            $("#LaborName").html(parametros.LaborName);
        }

        $("#btn-confirmar-peso").click(function () {
            var parametros = {
                "Fecha": $("#ProgFecha").val(),
                "Turno": $("#ProgTurno").val(),
                "Placa": $("#ProgPlaca").val(),
                "Labor": $("#ProgLabor").val(),
                "Peso": $("#ProgPeso").val(),
                "PesoNeto": $("#ProgPesoNeto").val()
            };
            var mensaje = "";
            var placas = $("table tbody tr td.placa");
            placas.each(function () {
                var placa = $(this).html();
                if (placa == $("#ProgPlaca").val()) {
                    mensaje = "El peso del vehiculo ya esta registrado...";
                }
            });
            if (mensaje != "") {
                PopInformativo(mensaje);
                return false;
            }
            GrabarCapturarPeso(parametros);
        });
    });
}

function GrabarCapturarPeso(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.GrabarCapturaPeso;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data!=null) {
            PopInformativo(data.Message);
            ListarProgramaciones(parametros);
            ListarDetalleProgramacionPeso(parametros);
            console.log("input:radio[data-labor=" + parametros.Labor);
            $("input:radio[data-labor=" + parametros.Labor).prop("checked", true);
        }
    });
}






