$(document).ready(function () {
    $("#IdDistribuir").click(function () {
        var fecha = $("input:radio[name=seleccion]:checked").attr("data-fecha");
        var turno = $("input:radio[name=seleccion]:checked").attr("data-turno");
        var parametros = { "Turno": turno, "Fecha": fecha };
        DistribuirEquipos(parametros);
        return false;
    });

    $("#IdCerrar").click(function () {

        //Validar 
        var estado = $("#TagCerrar").val();
        $("#success_message").hide();
        $("#success_message").empty();
        $("#alert_message").hide();
        $("#alert_message").empty();
        if (estado == false) {
            $("#alert_message").append('No se puede cerrar la distribucion. Se debe terminar de asignar los equipos!');
            $("#alert_message").show();
            return false;
        }
        var parametros = { "Turno": $("#TurnoPrograma").val(), "Fecha": $("#FechaPrograma").val() };
        CerrarDistribucion(parametros);
        return false
    });
    $(".seleccion").click(function () {
        $("#IdDistribuir").attr("disabled", false);
    });

    ListarEquiposActivos();
});

function DistribuirEquipos(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.DistribuirEquipos;
    info.parametros = parametros;
    $("#success_message").empty();
    $("#success_message").hide();
    ajaxPartialView(info, function (data) {
        if (data != "") {
            $("#IdProgramacionEquipos").html(data);
            $("#success_message").append("Se distribuyo los equipos!");
            $("#success_message").show();
            $("#FechaPrograma").val(parametros.Fecha);
            $("#TurnoPrograma").val(parametros.Turno);
            if ($("#TagCerrar").val() == "0") {
                $("#IdCerrar").attr("disabled", true);
            } else {
                $("#IdCerrar").attr("disabled", false);
            }
            ListarEquiposActivos();
            DisposeEvent(".btn-elegir");
            $(".btn-elegir").click(function () {
                var existe = $("#ExisteEquipo").val();
                if (existe == null || existe == "") {
                    PopInformativo("No hay equiois disponibles...");
                    return false;
                }
                    

                $("#success_message").empty();
                $("#success_message").hide();
                var LaborOr = $(this).attr("data-laboror");
                var LaborDe = $(this).attr("data-laborde");
                $("#LaborOrPrograma").val(LaborOr);
                $("#LaborDePrograma").val(LaborDe);
                $("#modalequipo").modal('show');
            });

            DisposeEvent(".btn-grabar");
            $(".btn-grabar").click(function () {
                var parametros = { "Fecha": $("#FechaPrograma").val(), "Turno": $("#TurnoPrograma").val(), "Laboror": $("#LaborOrPrograma").val(), "Laborde": $("#LaborDePrograma").val(), "IdEquipo": $("#Id_Equipo").val() };
                AsignarEquipo(parametros);
                return false;
            });

        }

    }, Error);
}

function AsignarEquipo(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.AsignarEquipo;
    info.parametros = parametros;
    $("#success_message").hide();
    ajax(info, function (data) {
        if (data == true) {
            ListarEquipos(parametros);
            $("#success_message").empty();
            $("#success_message").append("Equipo asignado!");
            $("#success_message").show();

            ListarEquiposActivos();
            $("#modalequipo").modal('hide');
        }

    }, Error);
}

function ListarEquipos(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarEquipos;
    info.parametros = parametros;
    ajaxPartialView(info, function (data) {
        if (data != "") {
            $("#IdProgramacionEquipos").html(data);
            $("#FechaPrograma").val(parametros.Fecha);
            $("#TurnoPrograma").val(parametros.Turno);
            if ($("#TagCerrar").val() == true) {
                $("#IdCerrar").attr("disabled", false);
            }
            DisposeEvent(".btn-elegir");
            $(".btn-elegir").click(function () {
                $("#success_message").empty();
                $("#success_message").hide();
                var LaborOr = $(this).attr("data-laboror");
                var LaborDe = $(this).attr("data-laborde");
                $("#LaborOrPrograma").val(LaborOr);
                $("#LaborDePrograma").val(LaborDe);
                $("#modalequipo").modal('show');
            });

            DisposeEvent(".btn-grabar");
            $(".btn-grabar").click(function () {
                var parametros = { "Fecha": $("#FechaPrograma").val(), "Turno": $("#TurnoPrograma").val(), "Laboror": $("#LaborOrPrograma").val(), "Laborde": $("#LaborDePrograma").val(), "IdEquipo": $("#Id_Equipo").val() };
                AsignarEquipo(parametros);
                return false;
            });

        }

    }, Error);
}

function ListarEquiposActivos() {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ListarEquiposActivos;
    ajax(info, function (data) {
        if (data != null && data.length > 0) {
            $("#alert_equipos").hide();
            CargarComboEquipo(data, "#Id_Equipo")
            $("#btn-grabar").attr('disabled', false);
            $("#Id_Equipo").show();
        } else {
            $("#Id_Equipo").hide();
            $("#alert_equipos").show();
            $("#btn-grabar").attr('disabled', true);
        }

    }, Error);
}


function CerrarDistribucion(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.CerrarDistribucion;
    info.parametros = parametros;
    $("#success_message").hide();
    ajax(info, function (data) {
        if (data == true) {
            $("#success_message").empty();
            $("#success_message").append("Equipos cerrado!");
            $("#success_message").show();
            $("#IdProgramacionEquipos").empty();
        }

    }, Error);
}

function CargarComboEquipo(data, objeto) {
    $(objeto + ' option').remove();
    $.each(data, function (i, item) {
        $(objeto).append("<option value='"
           + item.IdEquipo + "'>" + item.Equipo
           + "</option>");
    });
}