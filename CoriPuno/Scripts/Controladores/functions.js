function DisposeEvent(objeto) {
    $(objeto).off();
}

function DisposeEvent(objeto, evento) {
    $(document).off(evento, objeto);
}

function Visible(objeto) {
    $(objeto).show();
}

function Hidden(objeto) {
    $(objeto).hide();
}

function MostrarMensajeError(mensaje) {
    $("#Message-Error").empty();
    $("#Message-Error").append(mensaje);
    $("#Message-Error").show();

}
function MostrarMensajeOK(mensaje) {
    Hidden("#Message-Error");
    $("#Message-OK").empty();
    $("#Message-OK").append(mensaje);
    $("#Message-OK").show();
}

function PopInformativo(texto) {
    $("#MessagePopup").find("#modalmsg-texto").empty();
    $("#MessagePopup").find("#modalmsg-texto").append(texto);
    $("#MessagePopup").modal();

}

var Constantes = {
    SaltoHtml: "<br/>",
    ExpresionRegular: {
        DNI: "^[0-9]+$",
        Pasaporte: "^[ a-zA-ZñÑ0-9áéíóúÁÉÍÓÚ]+$",
        NombresApellidos: "^[A-Za-zÑñaáéíóúÁÉÍÓÚ' ]+$",
        Email: "^[0-9A-ZÑa-zñaáéíóúÁÉÍÓÚ@&.,#/' ]+$",
        Web: "^[0-9A-Za-zñÑaáéíóúÁÉÍÓÚ&._:,#/' ]+$",
        Telefono: "^[0-9]+$",
        Direccion: "^[0-9A-Za-zñÑaáéíóúÁÉÍÓÚ&.#/°' ]+$",
        Empresa: "^[0-9A-Za-zñÑaáéíóúÁÉÍÓÚ&.' ]+$",
        Ruc: "^[0-9]{11,11}$",
        SoloNumeros: "^[0-9]+$",
        SoloLetras: "^[A-Za-zñÑaáéíóúÁÉÍÓÚ]+$",
        NumerosLetras: "^[0-9A-Za-zñÑaáéíóúÁÉÍÓÚ_ ]+$",
        Clima: "^[0-9CF° ]+$",
        Poblacion: "^[0-9,. ]+$",
        Altitud: "^[0-9A-Z. ]+$",
        NumerosLetrasEspacio: "^[0-9A-Za-zñÑaáéíóúÁÉÍÓÚ ]+$",
        Precio: "^[0-9.,]+$",
        Parrafo: "^[0-9A-ZÑa-zñÁÉÍÓÚáéíóú&.,#/' ]+$",
    },
    Message: {
        //Mensaje Mantenimiento Labores
        FaltaCodigoLabor: "Ingresar el codigo de la labor.",
        FaltaDescripcionLabor: "Ingresar el nombre de la labor.",
        FaltaTipoLabor: "Ingresar el tipo de labor.",
        FaltaLeyLabor: "Ingresar la Ley de la labor.",
        FaltaCapMaximaLabor: "Ingresar la capacidad máxima de la labor.",
        FaltaPorRocaLabor: "Ingresar el por Roca de la labor.",
        FaltaAreaManoObraLabor: "Ingresar el area de la mano de obra de la labor.",
        FaltaFechaAperturaLabor: "Ingresar la fecha de apertura de la labor.",
        FaltaFechaLeyLabor: "Ingresar la fecha ley de la labor.",
        FaltaMinaLabor: "Ingresar la mina de la labor.",
        FaltaAreaLabor: "Ingresar el area de la labor.",
        FaltaZonaLabor: "Ingresar la zona de la labor.",
        FaltaPoligonoLabor: "Ingresar el poligono de la labor.",

        ErrorCodigoLabor: "Codigo de la labor incorrecto.",
        ErrorDescripcionLabor: "Nombre de la labor incorrecto.",
        ErrorLeyLabor: "Ley de la labor incorrecto.",
        ErrorCapMaximaLabor: "Capacidad máxima de la labor  incorrecto.",
        ErrorPorRocaLabor: "Por Roca de la labor incorrecto.",
        ErrorAreaManoObraLabor: "Área de la mano de obra de la labor incorrecto.",
        ErrorFechaAperturaLabor: "Fecha de apertura de la labor incorrecto.",

        //Mensaje Mantenimiento Rutas
        FaltaDistanciaRuta: "Ingresar la distancia de la ruta.",
        FaltaFactorRuta: "Ingresar el factor de la ruta.",

        ErrorDistanciaRuta: "La distancia de la ruta es incorrecto.",
        ErrorFactorRuta: "El factor de la ruta es incorrecto.",


    },
};
