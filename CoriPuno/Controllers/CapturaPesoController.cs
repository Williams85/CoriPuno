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
    public class CapturaPesoController : Controller
    {
        // GET: CapturaPeso
        public ActionResult Index()
        {
            ViewBag.TituloPagina = "Captura de Peso Transportado";
            return View();
        }

        [HttpPost]
        public ActionResult CapturarPeso(string placa)
        {
            VehiculoDominio oVehiculoDominio = new VehiculoDominio();
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            var vehiculo = oVehiculoDominio.obtenerDatosXFiltro(placa);
            if (vehiculo != null)
            {
                vehiculo.Peso = oProgramacionDiariaDominio.SimuladorPeso(vehiculo.Capacidad);
                vehiculo.PesoNeto = vehiculo.Peso - vehiculo.Tara;
            }
            return PartialView("_DatosVehiculo", vehiculo);
        }

        [HttpPost]
        public ActionResult ListarProgramacion(string Fecha, string Turno)
        {
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            var ListaProgramaciones = oProgramacionDiariaDominio.listarProgramacionCapturaPeso(DateTime.Parse(Fecha), Turno);
            return PartialView("_ListaProgramaciones", ListaProgramaciones);
        }

        [HttpPost]
        public ActionResult ListarDetalleProgramacionPeso(string Fecha, string Turno, string Placa, string Labor)
        {
            VehiculoDominio oVehiculoDominio = new VehiculoDominio();
            var ListaPeso = oVehiculoDominio.listarPesoVehiculo(DateTime.Parse(Fecha), Turno, Placa, Labor);
            return PartialView("_DetalleProgramacionPeso", ListaPeso);
        }

        [HttpPost]
        public ActionResult GrabarCapturaPeso(string Fecha, string Turno, string Placa, string Labor, string Peso, string PesoNeto)
        {
            ExtraccionBalanzaDominio oExtraccionBalanzaDominio = new ExtraccionBalanzaDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            oResponseWeb.Estado = oExtraccionBalanzaDominio.grabarDatos(new ExtraccionBalanzaEntidad
            {
                Fecha = DateTime.Parse(Fecha),
                Turno = Turno,
                Placa = Placa,
                Labor_or = Labor,
                Peso = decimal.Parse(Peso),
                PesoNeto = decimal.Parse(PesoNeto),
            });
            if (oResponseWeb.Estado)
                oResponseWeb.Message = "Se grabo el peso...";
            else
                oResponseWeb.Message = "No se grabo el peso...";
            return Json(oResponseWeb);
        }


    }
}