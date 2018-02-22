using CoriPuno.Data;
using CoriPuno.Dominio;
using CoriPuno.Entidad;
using CoriPuno.Models;
using CoriPuno.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoriPuno.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ParametrosDominio oParametrosDominio = new ParametrosDominio();
            LaborDominio oLaborDominio = new LaborDominio();
            var Parametros = oParametrosDominio.Listar();
            int CantidadOrigen = 0;
            int CantidadDestino = 0;
            int ParametroOrigen = Parametros.nLabor;
            int ParametroDestino = Parametros.nLabDest;

            var ListaLaborOrigen = oLaborDominio.obtenerDatosXFiltro(new LaborEntidad
            {
                Codigo = "",
                Descripcion = "",
                Tipo = "OR",
                Estado = "A",
            });

            var ListaLaborDestino = oLaborDominio.obtenerDatosXFiltro(new LaborEntidad
            {
                Codigo = "",
                Descripcion = "",
                Tipo = "DE",
                Estado = "A",
            });

            if (ListaLaborOrigen != null && ListaLaborOrigen.Count > 0)
                CantidadOrigen = ListaLaborOrigen.Count;

            if (ListaLaborDestino != null && ListaLaborDestino.Count > 0)
                CantidadDestino = ListaLaborDestino.Count;

            ViewBag.CantidadOrigen = CantidadOrigen;
            ViewBag.CantidadDestino = CantidadDestino;
            ViewBag.ParametroOrigen = ParametroOrigen;
            ViewBag.ParametroDestino = ParametroDestino;

            return View();
        }

        [HttpPost]
        public ActionResult CalcularProgramacion(decimal LeyMinima, decimal LeyMaxima, string Turno, string FEjecucion)
        {
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            int result = 0;
            var ListaProgramacion = oProgramacionDiariaDominio.generarProgramacion(DateTime.Parse(FEjecucion), Turno, LeyMinima, LeyMaxima, ref result);
            ViewBag.Mensaje = Functions.obtenerMensajeGeneracionProgramacion(result);
            return PartialView("_ViewProgramacion", ListaProgramacion);
        }

        [HttpPost]
        public ActionResult CerrarProgramacion(string Fecha, string Turno)
        {
            ProgramacionDiariaCabDominio oProgramacionDiariaCabDominio = new ProgramacionDiariaCabDominio();

            var resultado = oProgramacionDiariaCabDominio.cerrarProgramacion(DateTime.Parse(Fecha), Turno);
            return Json(resultado);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}