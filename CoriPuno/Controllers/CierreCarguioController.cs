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
    public class CierreCarguioController : Controller
    {
        // GET: CierreCarguio
        public ActionResult Index()
        {
            //System.IO.Ports.SerialPort port = new System.IO.Ports.SerialPort();
            //string texto="";
            //port.Open();
            //port.Write(texto);
            //var puerto = port.PortName;
            //foreach (var item in System.IO.Ports.SerialPort.GetPortNames)
            //{

            //}

            ProgramacionDiariaCabDominio oProgramacionDiariaCabDominio = new ProgramacionDiariaCabDominio();
            EquipoDominio oEquipoDominio = new EquipoDominio();
            var resultado = oProgramacionDiariaCabDominio.ProgramacionesGeneradas();
            return View(resultado);
        }

        [HttpPost]
        public ActionResult MostrarDetalleProgramacion(string Turno, string Fecha)
        {
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            var ListaDetalleProgramacion = oProgramacionDiariaDominio.listarDetalleProgramacion(DateTime.Parse(Fecha), Turno);

            return PartialView("_DetalleProgramacion", ListaDetalleProgramacion);

        }

        [HttpPost]
        public ActionResult ModificarEstadoProgramacion(string Turno, string Fecha, string Flag)
        {
            ResponseWeb oResponseWeb = new ResponseWeb();
            ProgramacionDiariaCabDominio oProgramacionDiariaCabDominio = new ProgramacionDiariaCabDominio();
            oResponseWeb.Estado = oProgramacionDiariaCabDominio.ProgramacionModificarEstado(DateTime.Parse(Fecha), Turno, Flag);

            return Json(oResponseWeb);

        }
        [HttpPost]
        public ActionResult MostrarProgramacion(string Turno, string Fecha)
        {
            ProgramacionDiariaCabDominio oProgramacionDiariaCabDominio = new ProgramacionDiariaCabDominio();
            EquipoDominio oEquipoDominio = new EquipoDominio();
            var resultado = oProgramacionDiariaCabDominio.ProgramacionesGeneradas();
            return PartialView("_ListaProgramacion", resultado);

        }

        [HttpPost]
        public ActionResult GrabarObservacion(RechazoProgramacionEntidad entidad)
        {
            RechazoProgramacionDominio oRechazoProgramacionDominio = new RechazoProgramacionDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            oResponseWeb.Estado = oRechazoProgramacionDominio.grabarDatos(entidad);
            if (oResponseWeb.Estado)
            {
                oResponseWeb.Message = "Se registro la observación...";
            }
            return Json(oResponseWeb);

        }

        [HttpPost]
        public ActionResult ListarObservacion(RechazoProgramacionEntidad entidad)
        {
            RechazoProgramacionDominio oRechazoProgramacionDominio = new RechazoProgramacionDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            var Lista = oRechazoProgramacionDominio.obtenerDatosXFiltro(entidad);
            return PartialView("_ListaObservaciones", Lista);

        }


    }
}