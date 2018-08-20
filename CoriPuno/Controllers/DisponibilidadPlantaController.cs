using CoriPuno.Dominio;
using CoriPuno.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoriPuno.Controllers
{
    public class DisponibilidadPlantaController : Controller
    {
        //
        // GET: /DisponibilidadPlanta/
        public ActionResult Index()
        {
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            var ListaStockDisponible = oProgramacionDiariaDominio.listarStockDisponible();
            return View(ListaStockDisponible);
        }

        [HttpPost]
        public ActionResult ActualizarStockDisponible(List<ProgramacionDiariaEntidad> Lista)
        {
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            var ListaStockDisponible = oProgramacionDiariaDominio.actualizarStockDisponible(Lista);
            return PartialView("_ActualizarStockDisponible", ListaStockDisponible);
        }


	}
}