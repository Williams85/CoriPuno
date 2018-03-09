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
        [Authentication]
    public class RutaController : Controller
    {
        // GET: Ruta
        public ActionResult Index()
        {
            ViewBag.TituloPagina = "Actualización de Rutas";
            return View();
        }


        [HttpPost]
        public ActionResult Edicion(int Codigo)
        {
            ViewBag.TituloPagina = "Actualización de Rutas";
            if (Codigo <=0) return RedirectToAction("Index", "Ruta");
            RutaDominio oRutaDominio = new RutaDominio();
            var oRutaEntidad = oRutaDominio.obtenerDatosXCodigo(Codigo);
            return View(oRutaEntidad);
        }

        [HttpPost]
        public ActionResult BuscarRutas(RutaEntidad entidad)
        {
            RutaDominio oRutaDominio = new RutaDominio();
            var ListaRuta= oRutaDominio.obtenerDatosXFiltro(entidad);

            return PartialView("_ResultadosBusqueda", ListaRuta);
        }


        [HttpPost]
        public ActionResult ModificarRutas(RutaEntidad entidad)
        {
            RutaDominio oRutaDominio = new RutaDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            oResponseWeb.Estado = oRutaDominio.modificarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }
    }
}