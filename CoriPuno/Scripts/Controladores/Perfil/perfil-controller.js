$(document).ready(function () {
    $("#btn-buscar").click(function () {
        var parametros = {
            "Nom_Perfil": $("#Nom_Perfil").val()
        };
        Buscar(parametros);
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
            $(".view-paquetes").hide();
            $(".view-paginas").hide();

            $(".btn-mostrar-paquete").on("click", function () {
                //console.log($(this).parents("tr").next().html());
                $(this).parents("tr").next().toggle("slow");
                $(this).parents("tr").next().find(".view-paginas").hide();
                //if ($(this).parents("tr").next().is(":hidden")) {
                //    console.log('Elemento visible');
                //} else {
                //    console.log('Elemento oculto');
                //}
            });

            $(".btn-mostrar-pagina").on("click", function () {
                $(this).parents("tr").next().toggle("slow");
            });


        }
    });
}