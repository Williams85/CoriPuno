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
    public class VehiculoController : Controller
    {
        //
        // GET: /Vehiculo/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Nuevo()
        {
            ViewBag.TituloPagina = Message.TituloVehiculo;
            ContrataDominio oContrataDominio = new ContrataDominio();
            ViewBag.ListaContrata = oContrataDominio.Listar();
            return View();
        }

        [HttpPost]
        public ActionResult Edicion(string Codigo)
        {
            ViewBag.TituloPagina = Message.TituloVehiculo;
            if (Codigo == null) return RedirectToAction("Index", "Vehiculo");
            VehiculoDominio oVehiculoDominio = new VehiculoDominio();
            ContrataDominio oContrataDominio = new ContrataDominio();
            ViewBag.ListaContrata = oContrataDominio.Listar();
            var oVehiculo = oVehiculoDominio.obtenerDatosXCodigo(Codigo);
            return View(oVehiculo);
        }

        [HttpPost]
        public ActionResult Buscar(VehiculoEntidad entidad)
        {
            VehiculoDominio oVehiculoDominio = new VehiculoDominio();
            var ListaVehiculos = oVehiculoDominio.Filtrar(entidad);
            return PartialView("_ResultadosBusqueda", ListaVehiculos);
        }

        [HttpPost]
        public ActionResult Grabar(VehiculoEntidad entidad)
        {
            VehiculoDominio oVehiculoDominio = new VehiculoDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string mensaje = string.Empty;
            oResponseWeb.Estado = oVehiculoDominio.grabarDatos(entidad, ref mensaje);
            oResponseWeb.Message = mensaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult Modificar(VehiculoEntidad entidad)
        {
            VehiculoDominio oVehiculoDominio = new VehiculoDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string mensaje = string.Empty;
            oResponseWeb.Estado = oVehiculoDominio.modificarDatos(entidad, ref mensaje);
            oResponseWeb.Message = mensaje;
            return Json(oResponseWeb);
        }

	}
}