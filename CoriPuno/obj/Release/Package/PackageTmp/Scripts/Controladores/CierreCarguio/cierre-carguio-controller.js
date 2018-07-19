$(document).ready(function () {

    Hidden("#Message-Error");
    Hidden("#Message-OK");
    $("input:radio[name=seleccion]").click(function () {
        var fecha = $(this).attr("data-fecha");
        var turno = $(this).attr("data-turno");
        var parametros = { "Turno": turno, "Fecha": fecha };
        $("#FechaPrograma").val(fecha);
        $("#TurnoPrograma").val(turno);
        $("#IdAprobado").attr('disabled', false);
        $("#IdRechazado").attr('disabled', false);
        MostrarDetalleProgramacion(parametros);
    });

    $("#IdAprobado").click(function () {
        var parametros = {
            "Fecha": $("#FechaPrograma").val(),
            "Turno": $("#TurnoPrograma").val(),
            "Flag": "C",
        };
        ActualizarEstado(parametros);
        return false;
    });

    $("#IdRechazado").click(function () {
        $("#ObservacionPopup").modal();
        return false;
    });

    $("#btn-Observacion").click(function () {
        var parametros = {
            "Fecha": $("#FechaPrograma").val(),
            "Turno": $("#TurnoPrograma").val(),
            "MotivoRechazo": $.trim($("#IdObservacion").val()),
        }
        GrabarObservacion(parametros);
        $("#IdObservacion").val("");
        return false;
    });

    $(".btn-lista-observacion").click(function () {
        var fecha = $(this).attr("data-fecha");
        var turno = $(this).attr("data-turno");
        var parametros = { "Turno": turno, "Fecha": fecha };
        ListarObservaciones(parametros);
    });

});

function MostrarDetalleProgramacion(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.MostrarDetalleProgramacion;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdDetalleProgramacion").html(data);
        }
    });
}

function ActualizarEstado(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ModificarEstadoProgramacion;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data.Estado == true) {
            if (parametros.Flag == "A") {
                $("#success_message").append("Se aprobo la programación de carguio...");
            } else {
                $("#success_message").append("Se rechazo la programación de carguio...");
            }
            MostrarProgramacion();

        }
    });
}

function MostrarProgramacion() {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.MostrarProgramacion;
    info.parametros = {};

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#IdProgramaciones").empty();
            $("#IdDetalleProgramacion").empty();
            $("#IdProgramaciones").html(data);
            $(".btn-lista-observacion").click(function () {
                var fecha = $(this).attr("data-fecha");
                var turno = $(this).attr("data-turno");
                var parametros = { "Turno": turno, "Fecha": fecha };
                ListarObservaciones(parametros);
            });
        }
    });

}

function GrabarObservacion(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.GrabarObservacion;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data.Estado == true) {
            $("#ObservacionPopup").modal('hide');
            PopInformativo(data.Message);
            MostrarProgramacion();
        }
    });
}

function ListarObservaciones(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarObservacion;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {
        if (data != null) {
            $("#ListaObservacionPopup #contenido").html(data);
            $("#ListaObservacionPopup").modal();
        }
    });
}




