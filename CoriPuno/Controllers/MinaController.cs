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
    public class MinaController : Controller
    {
        //
        // GET: /Mina/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = Message.TituloMina;
            return View();
        }

        public ActionResult Nuevo()
        {
            ViewBag.TituloPagina = Message.TituloMina;
            return View();
        }

        [HttpPost]
        public ActionResult Edicion(string Codigo)
        {
            ViewBag.TituloPagina = Message.TituloMina;
            if (Codigo == null) return RedirectToAction("Index", "Mina");
            MinaDominio oMinaDominio = new MinaDominio();
            var oMina = oMinaDominio.obtenerDatosXCodigo(Codigo);
            return View(oMina);
        }

        [HttpPost]
        public ActionResult Buscar(MinaEntidad entidad)
        {
            MinaDominio oMinaDominio = new MinaDominio();
            var ListaMinas = oMinaDominio.obtenerDatosXFiltro(entidad);
            return PartialView("_ResultadosBusqueda", ListaMinas);
        }

        [HttpPost]
        public ActionResult Grabar(MinaEntidad entidad)
        {
            MinaDominio oMinaDominio = new MinaDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            oResponseWeb.Estado = oMinaDominio.grabarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult Modificar(MinaEntidad entidad)
        {
            MinaDominio oMinaDominio = new MinaDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            oResponseWeb.Estado = oMinaDominio.modificarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }
	}
}