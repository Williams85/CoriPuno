using CoriPuno.Dominio;
using CoriPuno.Entidad;
using CoriPuno.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoriPuno.Controllers
{
    public class FormulacionIndicadoresController : Controller
    {
        //
        // GET: /FormulacionIndicadores/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = Message.TituloFormIndicadores;
            return View();
        }


        public ActionResult Nuevo()
        {
            ComponenteDominio oComponenteDominio = new ComponenteDominio();
            var ListaComponentes = oComponenteDominio.obtenerDatosXFiltro(new ComponenteEntidad
            {
                Descripcion = string.Empty,
                Sigla = string.Empty,
                UnidadMedida = string.Empty
            });
            ViewBag.ListaComponentes = ListaComponentes;
            return View();
        }


        [HttpPost]
        public ActionResult Edicion(string Codigo)
        {
            ComponenteDominio oComponenteDominio = new ComponenteDominio();
            var ListaComponentes = oComponenteDominio.obtenerDatosXFiltro(new ComponenteEntidad
            {
                Descripcion = string.Empty,
                Sigla = string.Empty,
                UnidadMedida = string.Empty
            });
            IndicadorDominio oIndicadorDominio = new IndicadorDominio();
            var entidad = oIndicadorDominio.obtenerDatosXCodigo(Codigo);
            ViewBag.ListaComponentes = ListaComponentes;
            return View(entidad);
        }

        [HttpPost]
        public ActionResult Buscar(IndicadorEntidad entidad)
        {
            IndicadorDominio oIndicadorDominio = new IndicadorDominio();
            var ListaIndicadores = oIndicadorDominio.obtenerDatosXFiltro(entidad);
            return PartialView("_ResultadosBusqueda", ListaIndicadores);
        }

        [HttpPost]
        public ActionResult Grabar(IndicadorEntidad entidad)
        {
            IndicadorDominio oIndicadorDominio = new IndicadorDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            oResponseWeb.Estado = oIndicadorDominio.grabarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult Modificar(IndicadorEntidad entidad)
        {
            IndicadorDominio oIndicadorDominio = new IndicadorDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string mensaje = string.Empty;
            oResponseWeb.Estado = oIndicadorDominio.modificarDatos(entidad, ref mensaje);
            oResponseWeb.Message = mensaje;
            return Json(oResponseWeb);
        }

    }
}