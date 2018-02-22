using CoriPuno.Dominio;
using CoriPuno.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoriPuno.Controllers
{
    public class DistribucionMaquinariaController : Controller
    {
        // GET: DistribucionMaquinaria
        public ActionResult Index()
        {
            ProgramacionDiariaCabDominio oProgramacionDiariaCabDominio = new ProgramacionDiariaCabDominio();
            EquipoDominio oEquipoDominio = new EquipoDominio();
            var resultado = oProgramacionDiariaCabDominio.listarProgramacionPendientes();
            var listaEquipos = oEquipoDominio.listarEquipos();
            ViewBag.ListaEquipos = listaEquipos;
            return View(resultado);
        }

        [HttpPost]
        public ActionResult DistribuirEquipos(string Turno, string Fecha)
        {

            try
            {
                DistribucionEquiposDominio oDistribucionEquiposDominio = new DistribucionEquiposDominio();
                EquipoDominio oEquipoDominio = new EquipoDominio();
                var ListaProgramacion = oDistribucionEquiposDominio.distribuirEquiposProgramacion(DateTime.Parse(Fecha), Turno);

                var listaEquipos = oEquipoDominio.listarEquipos();
                ViewBag.CerrarProgramacion = "";
                ViewBag.ExisteEquipos = "";
                if (listaEquipos != null && listaEquipos.Count >= 1)
                    ViewBag.ExisteEquipos = "1";
                if (ListaProgramacion.Exists(x => x.Equipo == null))
                    ViewBag.CerrarProgramacion = "0";
                else
                    ViewBag.CerrarProgramacion = "1";
                return PartialView("_ViewProgramacionEquipos", ListaProgramacion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult ListarEquipos(string Turno, string Fecha)
        {
            DistribucionEquiposDominio oDistribucionEquiposDominio = new DistribucionEquiposDominio();
            var ListaProgramacion = oDistribucionEquiposDominio.listarEquiposProgramacion(DateTime.Parse(Fecha), Turno);

            ViewBag.CerrarProgramacion = ListaProgramacion.Exists(x => x.Equipo == "");
            return PartialView("_ViewProgramacionEquipos", ListaProgramacion);
        }

        [HttpPost]
        public ActionResult ListarEquiposActivos()
        {
            EquipoDominio oEquipoDominio = new EquipoDominio();
            var listaEquipos = oEquipoDominio.listarEquipos();
            return Json(listaEquipos);
        }

        [HttpPost]
        public ActionResult AsignarEquipo(string Fecha, string Turno, string Laboror, string Laborde, int IdEquipo)
        {
            DistribucionEquiposDominio oDistribucionEquiposDominio = new DistribucionEquiposDominio();

            var resultado = oDistribucionEquiposDominio.asignarEquipo(DateTime.Parse(Fecha), Turno, Laboror, Laborde, IdEquipo);
            return Json(resultado);
        }

        [HttpPost]
        public ActionResult CerrarDistribucion(string Fecha, string Turno)
        {
            DistribucionEquiposDominio oDistribucionEquiposDominio = new DistribucionEquiposDominio();

            var resultado = oDistribucionEquiposDominio.cerrarProgramacionEquipos(DateTime.Parse(Fecha), Turno);
            return Json(resultado);
        }

    }
}