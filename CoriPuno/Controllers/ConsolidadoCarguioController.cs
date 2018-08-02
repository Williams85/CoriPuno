using CoriPuno.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoriPuno.Controllers
{
    public class ConsolidadoCarguioController : Controller
    {
        //
        // GET: /ConsolidadoCarguio/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = "Elaboración Consolidado de Carguio";
            return View();
        }

        [HttpPost]
        public ActionResult BuscarConsolidadoCarguio(string Fecha)
        {
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            var ListaConsolidadoCarguio = oProgramacionDiariaDominio.listarConsolidadoCarguio(DateTime.Parse(Fecha));
            return PartialView("_ResultadoBusqueda", ListaConsolidadoCarguio);
        }


	}
}