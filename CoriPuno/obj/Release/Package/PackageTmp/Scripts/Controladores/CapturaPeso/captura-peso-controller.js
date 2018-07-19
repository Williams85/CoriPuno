$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");

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
            var Labor_Id = $(this).attr("data-labor");
            var Labor_Name = $(this).attr("data-labor-name");

            $("#ProgLabor").val(Labor_Id);
            var parametros = {
                "Fecha": $("#ProgFecha").val(),
                "Turno": $("#ProgTurno").val(),
                "Placa": $("#ProgPlaca").val(),
                "Labor": Labor_Id,
                "LaborName": Labor_Name,
            };
            var mensaje = "";
            if (parametros.Placa == null || parametros.Placa == "")
                mensaje += "Ingresar la placa del vehículo... <br/>";
            if (parametros.Fecha == null || parametros.Fecha == "")
                mensaje += "Ingresar la fecha de la programación... <br/>";
            if (parametros.Turno == null || parametros.Turno == "")
                mensaje += "Ingresar el turno de la programación... <br/>";

            if (mensaje != "") {
                MostrarMensajeError(mensaje);
                return false;
            }
            ListarDetalleProgramacionPeso(parametros);
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






