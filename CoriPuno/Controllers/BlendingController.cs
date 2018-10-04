using CoriPuno.Dominio;
using CoriPuno.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoriPuno.Controllers
{
    public class BlendingController : Controller
    {
        //
        // GET: /Blending/
        public ActionResult Index()
        {
            EquipoDominio oEquipoDominio = new EquipoDominio();
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            ViewBag.ListaEquipos = oEquipoDominio.EquiposActivos();
            var ListaStockDisponible = oProgramacionDiariaDominio.buscarStockDisponible();
            return View(ListaStockDisponible);
        }

        [HttpPost]
        public ActionResult EjecucionBlending(string FechaProceso, decimal Capacidad)
        {
            BlendingDominio oBlendingDominio = new BlendingDominio();
            string Mensaje = string.Empty;
            var entidad = oBlendingDominio.EjecucionBlending(FechaProceso, Capacidad, ref Mensaje);
            ViewBag.Mensaje = Mensaje;
            return PartialView("_ResultadoEjecucionBlending", entidad);
        }

        [HttpPost]
        public ActionResult ConfirmarBlending(string FechaProceso)
        {
            BlendingDominio oBlendingDominio = new BlendingDominio();
            string Mensaje = string.Empty;
            var indicador = oBlendingDominio.ConfirmarBlending(FechaProceso);
            ResponseWeb oResponseWeb = new ResponseWeb();
            oResponseWeb.Estado = (indicador == 0 ? true : false);
            return Json(oResponseWeb);
        }


        [HttpPost]
        public ActionResult EliminarBlending(string FechaProceso)
        {
            BlendingDominio oBlendingDominio = new BlendingDominio();
            string Mensaje = string.Empty;
            var indicador = oBlendingDominio.EliminarBlending(FechaProceso);
            ResponseWeb oResponseWeb = new ResponseWeb();
            oResponseWeb.Estado = (indicador == 0 ? true : false);
            return Json(oResponseWeb);
        }


    }
}