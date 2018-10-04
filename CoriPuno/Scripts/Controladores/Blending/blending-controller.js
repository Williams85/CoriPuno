$(document).ready(function () {

    MostrarCapacidad();
    $("#idEquipo").on("click", function () {
        MostrarCapacidad();
    });

    $("#idEjecBlending").on("click", function () {
        var parametros = {
            "FechaProceso": $("#FechaProceso").val(),
            "Capacidad": $("#idCapacidad").val(),
        };
        EjecucionBlending(parametros);
    });
});

function MostrarCapacidad() {
    var valor = $("#idEquipo option:selected").text();
    var capacidad = valor.split("-");
    $("#idCapacidad").val(capacidad[1]);
}

function EjecucionBlending(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.EjecucionBlending;
    info.parametros = parametros;

    ajaxPartialView(info, function (data) {

        if (data != null) {
            $("#ResultadoBlending").empty();
            $("#ResultadoBlending").html(data);

            $("#btnConfirmar").on("click", function () {
                var parametros = {
                    "FechaProceso": $("#FechaProceso").val()
                };
                ConfirmarBlending(parametros);
                return false;
            });

            $("#btnEliminar").on("click", function () {
                var parametros = {
                    "FechaProceso": $("#FechaProceso").val()
                };
                EliminarBlending(parametros);
                return false;
            });

        }
    });
}

function ConfirmarBlending(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.ConfirmarBlending;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null) {
            if (data.Estado == true)
                PopInformativo("Procedimiento conforme..");
            else
                PopInformativo("Generación ha tenido errores...");
        }
    });
}

function EliminarBlending(parametros) {
    //Consultar Controlador
    var info = new Object();
    info.metodo = "POST";
    info.serviceURL = rutas.EliminarBlending;
    info.parametros = parametros;

    ajax(info, function (data) {
        if (data != null) {
            if (data.Estado == true)
                PopInformativo("Eliminación conforme...");
            else
                PopInformativo("No se pudo eliminar...");
        }
    });
}
