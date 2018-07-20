$.datepicker.regional['es'] = {
    closeText: 'Cerrar',
    prevText: '<Ant',
    nextText: 'Sig>',
    currentText: 'Hoy',
    monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
    monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
    dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
    dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
    dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
    weekHeader: 'Sm',
    dateFormat: 'dd/mm/yy',
    firstDay: 1,
    isRTL: false,
    showMonthAfterYear: false,
    yearSuffix: ''
};
$.datepicker.setDefaults($.datepicker.regional['es']);

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
        SoloLetras: "^[A-Za-zñÑaáéíóúÁÉÍÓÚ ]+$",
        NumerosLetras: "^[0-9A-Za-zñÑaáéíóúÁÉÍÓÚ_ ]+$",
        Clima: "^[0-9CF° ]+$",
        Poblacion: "^[0-9,. ]+$",
        Altitud: "^[0-9A-Z. ]+$",
        NumerosLetrasEspacio: "^[0-9A-Za-zñÑaáéíóúÁÉÍÓÚ ]+$",
        Precio: "^[0-9.,]+$",
        Parrafo: "^[0-9A-ZÑa-zñÁÉÍÓÚáéíóú&.,#/' ]+$",
    },
    Message: {


        //Login
        FaltaUsuario: "Falta usuario",
        FaltaPassword: "Falta clave",
        ErrUserPass: "No se pudo validar credenciales.",

        //Mensaje Mantenimiento Poligonos
        FaltaPoligono: "Ingresar la descripcion",
        FaltaMinaPoligono: "Ingresar la mina",
        FaltaAreaPoligono: "Ingresar el area",
        FaltaZonaPoligono: "Ingresar la zona",
        ErrorPoligono: "Poligono incorrecto",

        //Mensaje Mantenimiento Zonas
        FaltaZona: "Ingresar la descripcion",
        FaltaMinaZona: "Ingresar la mina",
        FaltaAreaZona: "Ingresar el area",
        FaltaFechaInicioZona: "Ingresar la fecha de inicio",
        ErrorZona: "Mina incorrecto",

        //Mensaje Mantenimiento Vehiculo y Maquinaria
        FaltaPlaca: "Ingresar la placa",
        FaltaTara: "Ingresar la tara",
        FaltaCapacidad: "Ingresar la capacidad",
        FaltaContrata: "Ingresar la contrata",
        FaltaMarca: "Ingresar la marca",
        ErrorTara: "Tara incorrecta",
        ErrorCapacidad: "Capacidad incorrecta",
        ErrorContrata: "Contrata incorrecta",
        ErrorMarca: "Marca incorrecta",

        //Mensaje Mantenimiento Componentes
        FaltaComponente: "Ingresar el componente",
        FaltaSigla: "Ingresar la sigla",
        FaltaUndMedida: "Ingresar la unidad de medida",
        FaltaFuente: "Ingresar la fuente",
        FaltaProcedimiento: "Ingresar el procedimiento",
        ErrorComponente: "Componente incorrecta",
        ErrorSigla: "Sigla incorrecta",
        ErrorUndMedida: "Unidad de Medida incorrecta",
        ErrorFuente: "Fuente incorrecta",
        ErrorProcedimiento: "Procedimiento incorrecta",
        //ErrorTara: "Tara incorrecta",
        //ErrorCapacidad: "Capacidad incorrecta",
        //ErrorContrata: "Contrata incorrecta",
        //ErrorMarca: "Marca incorrecta",

        //Mensaje Mantenimiento Mina
        FaltaMina: "Ingresar la descripcion",
        FaltaFechaInicioMina: "Ingresar la fecha de inicio",
        FaltaFechaFinMina: "Ingresar la fecha de fin",
        ErrorMina: "Mina incorrecto",

        //Mensaje Mantenimiento Usuario
        FaltaUsuario: "Ingresar el usuario",
        FaltaPassword: "Ingresar el password",
        FaltaPerfilUsuario: "Ingresar el perfil del usuario",
        FaltaPerfilAcceso: "Ingresar el perfil de acceso",
        ErrorUsuario: "Usuario incorrecto",
        ErrorPerfilUsuario: "Perfil del usuario incorrecto",

        //Mensaje de Cambio Clave
        FaltaClaveActual: "Ingresar la clave actual...",
        FaltaClaveNueva: "Ingresar la nueva clave...",
        FaltaClaveNuevaConfirmada: "Ingresar la confirmación de la nueva clave...",
        ErrorClaveActual: "La clave actual ingresada no es correcta...",
        ErrorDifClaveActual: "La clave actual y nueva deben ser diferentes...",
        ErrorIgualClaveNueva: "La clave nueva y clave nueva confirmada son diferentes...",
        NoCambioClave: "No se cambio la clave...",
        CambioClave: "Se cambio la clave...",

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
