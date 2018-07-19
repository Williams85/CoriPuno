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
    public class ModificacionPesoController : Controller
    {
        // GET: ModificacionPeso
        public ActionResult Index()
        {
            ViewBag.TituloPagina = "Autorización de Modificación de Pesos";
            ExtraccionBalanzaDominio oExtraccionBalanzaDominio = new ExtraccionBalanzaDominio();
            ViewBag.ListaVehiculos = oExtraccionBalanzaDominio.listarVehiculos();
            return View();
        }

        [HttpPost]
        public ActionResult ListarLabores(string Fecha,string Placa)
        { 
            ExtraccionBalanzaDominio oExtraccionBalanzaDominio = new ExtraccionBalanzaDominio();
            var ListaDetallePeso = oExtraccionBalanzaDominio.listarDetalleProgramacion(DateTime.Parse(Fecha), Placa);
            return PartialView("_ListaLabores",ListaDetallePeso);
        }

        [HttpPost]
        public ActionResult GrabarModificacioNPeso(ExtraccionBalanzaEntidad entidad)
        {
            ExtraccionBalanzaDominio oExtraccionBalanzaDominio = new ExtraccionBalanzaDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            oResponseWeb.Estado = oExtraccionBalanzaDominio.modificarDatos(entidad);
            if (oResponseWeb.Estado)
                oResponseWeb.Message = "Se modifico el peso...";
            else
                oResponseWeb.Message = "No se modifico el peso...";
            return Json(oResponseWeb);
        }


    }
}