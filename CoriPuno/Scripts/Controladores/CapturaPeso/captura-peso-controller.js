$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");
    Hidden("#ConfirmarCapturaPeso");
    $("#btn-capturar-peso").click(function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var parametros = {
            "placa": $("#Placa").val(),
        }
        var mensaje = "";
        if (parametros.placa == null || parametros.placa == "")
            mensaje = "Ingresar la placa";

        if (mensaje != "") {
            MostrarMensajeError(mensaje);
            return false;
        }
        $("#ProgPlaca").val(parametros.placa);
        CapturarPeso(parametros);
        return false;
    });

    $("#Turno").change(function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var parametros = {
            "Fecha": $("#Fecha").val(),
            "Turno": $("#Turno").val(),
        }

        var mensaje = "";
        if (parametros.Fecha == null || parametros.Fecha == "")
            mensaje = "Ingresar la fecha <br/>";

        if (mensaje != "") {
            MostrarMensajeError(mensaje);
            return false;
        }

        $("#ProgFecha").val(parametros.Fecha);
        $("#ProgTurno").val(parametros.Turno);

        ListarProgramaciones(parametros);
        return false;
    });

    $("#Fecha").blur(function () {
        Hidden("#Message-Error");
        Hidden("#Message-OK");
        var parametros = {
            "Fecha": $("#Fecha").val(),
            "Turno": $("#Turno").val(),
        }

        var mensaje = "";
        if (parametros.Fecha == null || parametros.Fecha == "")
            mensaje = "Ingresar la fecha <br/>";

        if (mensaje != "") {
            MostrarMensajeError(mensaje);
            return false;
        }

        $("#ProgFecha").val(parametros.Fecha);
        $("#ProgTurno").val(parametros.Turno);

        ListarProgramaciones(parametros);
        return false;
    });

    $("#btn-confirmar-peso").click(function () {
        $("#ConfirmarCapturaPeso").modal('hide');
        var parametros = {
            "Fecha": $("#ProgFecha").val(),
            "Turno": $("#ProgTurno").val(),
            "Placa": $("#ProgPlaca").val(),
            "Labor": $("#ProgLaborOrigen").val(),
            "Labor_Origen": $("#ProgLaborOrigen").val(),
            "Labor_Destino": $("#ProgLaborDestino").val(),
            "Peso": $("#ProgPeso").val(),
            "PesoNeto": $("#ProgPesoNeto").val()
        };
        var mensaje = "";
        var TM_Prog = $("#ProgTMProg").val();
        var TM_Ejec = $("#ProgTMEjec").val();

        if ($.trim($("#IdVehiculo").html()) == "") {
            mensaje = "Capturar el peso del vehículo...";
        } else {
            if (parseFloat(TM_Prog) < (parseFloat(TM_Ejec) + parseFloat(parametros.PesoNeto))) {
                mensaje = "Ya se cumplio la labor para esta ejecucion...";
            } else {
                var placas = $("table tbody tr td.placa");
                placas.each(function () {
                    var placa = $(this).html();
                    if (placa == $("#ProgPlaca").val()) {
                        mensaje = "El peso del vehiculo ya esta registrado...";
                    }
                });
            }
        }

        $(".seleccion-prog").prop("checked", false);
        if (mensaje != "") {
            PopInformativo(mensaje);
            return false;
        }

        GrabarCapturarPeso(parametros);
    });


});

function CapturarPeso(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.CapturarPeso;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdVehiculo").empty();
            $("#IdVehiculo").html(data);
        }
    });
}


function ListarProgramaciones(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarProgramacion;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {

        if (data != null) {
            $("#IdLabores").empty();
            $("#IdLabores").html(data);
        }
        $("input:radio[name=seleccion-prog]").click(function () {

            var Labor_Id_Origen = $(this).attr("data-labor-origen");
            var Labor_Id_Destino = $(this).attr("data-labor-destino");
            var TM_Prog = $(this).attr("data-tm-prog");
            var TM_Ejec = $(this).attr("data-tm-ejec");

            var Labor_Name = $(this).attr("data-labor-name");

            $("#ProgLaborOrigen").val(Labor_Id_Origen);
            $("#ProgLaborDestino").val(Labor_Id_Destino);
            $("#ProgTMProg").val(TM_Prog);
            $("#ProgTMEjec").val(TM_Ejec);
            $("#btn-exportar-detalle").hide();
            $("#ConfirmarCapturaPeso").modal('show');
            //$("#btn-confirmar-peso").show();
            //var parametros = {
            //    "Fecha": $("#ProgFecha").val(),
            //    "Turno": $("#ProgTurno").val(),
            //    "Placa": $("#ProgPlaca").val(),
            //    "Labor": Labor_Id,
            //    "LaborName": Labor_Name,
            //};
            //var mensaje = "";
            //if (parametros.Placa == null || parametros.Placa == "")
            //    mensaje += "Ingresar la placa del vehículo... <br/>";
            //if (parametros.Fecha == null || parametros.Fecha == "")
            //    mensaje += "Ingresar la fecha de la programación... <br/>";
            //if (parametros.Turno == null || parametros.Turno == "")
            //    mensaje += "Ingresar el turno de la programación... <br/>";

            //if (mensaje != "") {
            //    MostrarMensajeError(mensaje);
            //    return false;
            //}
            //ListarDetalleProgramacionPeso(parametros);
        });

        $("#btn-exportar-detalle").on("click", function () {
            ExportarExcel();
        });
    });
}


function ListarDetalleProgramacionPeso(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarDetalleProgramacionPeso;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {

        if (data != null && data.Estado) {
            console.log("OK")
            //$("#IdLaborOrigen").empty();
            //$("#IdLaborOrigen").html(data);
            //$("#LaborName").html(parametros.LaborName);
        }

        //$("#btn-confirmar-peso").click(function () {
        //    var parametros = {
        //        "Fecha": $("#ProgFecha").val(),
        //        "Turno": $("#ProgTurno").val(),
        //        "Placa": $("#ProgPlaca").val(),
        //        "Labor": $("#ProgLabor").val(),
        //        "Peso": $("#ProgPeso").val(),
        //        "PesoNeto": $("#ProgPesoNeto").val()
        //    };
        //    var mensaje = "";
        //    var placas = $("table tbody tr td.placa");
        //    placas.each(function () {
        //        var placa = $(this).html();
        //        if (placa == $("#ProgPlaca").val()) {
        //            mensaje = "El peso del vehiculo ya esta registrado...";
        //        }
        //    });
        //    if (mensaje != "") {
        //        PopInformativo(mensaje);
        //        return false;
        //    }
        //    GrabarCapturarPeso(parametros);
        //});
    });
}

function GrabarCapturarPeso(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.GrabarCapturaPeso;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null) {
            PopInformativo(data.Message);
            ListarProgramaciones(parametros);
            ListarDetalleProgramacionPeso(parametros);
            //$("input:radio[data-labor=" + parametros.Labor).prop("checked", true);
            $("#IdVehiculo").empty();
            $('#Placa option:eq(0)').prop('selected', true);
            $("#btn-exportar-detalle").show();
        }
    });
}


function ExportarExcel() {
    window.open('/CapturaPeso/ExportarExcel/');
}



