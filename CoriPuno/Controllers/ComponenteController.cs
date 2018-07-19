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
    public class ComponenteController : Controller
    {
        //
        // GET: /Componente/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = Message.TituloComponente;
            return View();
        }

        public ActionResult Nuevo()
        {
            ViewBag.TituloPagina = Message.TituloComponente;
            return View();
        }

        [HttpPost]
        public ActionResult Edicion(string Codigo)
        {
            ViewBag.TituloPagina = Message.TituloComponente;
            if (Codigo == null) return RedirectToAction("Index", "Componente");
            ComponenteDominio oComponenteDominio = new ComponenteDominio();
            var oComponente = oComponenteDominio.obtenerDatosXCodigo(Codigo);
            return View(oComponente);
        }

        [HttpPost]
        public ActionResult Buscar(ComponenteEntidad entidad)
        {
            ComponenteDominio oComponenteDominio = new ComponenteDominio();
            var ListaComponentes = oComponenteDominio.obtenerDatosXFiltro(entidad);
            return PartialView("_ResultadosBusqueda", ListaComponentes);
        }

        [HttpPost]
        public ActionResult Grabar(ComponenteEntidad entidad)
        {
            ComponenteDominio oComponenteDominio = new ComponenteDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            oResponseWeb.Estado = oComponenteDominio.grabarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult Modificar(ComponenteEntidad entidad)
        {
            ComponenteDominio oComponenteDominio = new ComponenteDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            oResponseWeb.Estado = oComponenteDominio.modificarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }
	}
	
}