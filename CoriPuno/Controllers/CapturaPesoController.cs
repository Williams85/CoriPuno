using CoriPuno.Dominio;
using CoriPuno.Entidad;
using CoriPuno.Utilitario;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CoriPuno.Controllers
{
    [Authentication]
    public class CapturaPesoController : Controller
    {
        // GET: CapturaPeso
        public ActionResult Index()
        {
            ViewBag.TituloPagina = "Captura de Peso Transportado";
            VehiculoDominio oVehiculoDominio = new VehiculoDominio();
            ViewBag.ListaVehiculos = oVehiculoDominio.Filtrar(new VehiculoEntidad
            {
                Placa = "",
                Marca = ""
            });
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
            Session["DetalleProgramacion"] = (List<VehiculoEntidad>)ListaPeso;
            ResponseWeb oResponseWeb = new ResponseWeb();
            if (ListaPeso.Count > 0) { oResponseWeb.Estado = true; }
            return Json(oResponseWeb);
        }

        public ActionResult ExportarExcel(string Fecha, string Turno, string Placa, string Labor)
        {
            List<VehiculoEntidad> ListaVehiculos = new List<VehiculoEntidad>();
            GridView gv = new GridView();
            string filename = string.Empty;
            if (Session["DetalleProgramacion"] != null)
            {
                ListaVehiculos = (List<VehiculoEntidad>)Session["DetalleProgramacion"];
                filename = "DetallePesoVehiculo.xls";
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn { ColumnName = "Placa" });
                dt.Columns.Add(new DataColumn { ColumnName = "Contrata" });
                dt.Columns.Add(new DataColumn { ColumnName = "Tara" });
                dt.Columns.Add(new DataColumn { ColumnName = "Hora Pesaje" });
                dt.Columns.Add(new DataColumn { ColumnName = "Peso" });
                dt.Columns.Add(new DataColumn { ColumnName = "Peso Neto" });
                foreach (var item in ListaVehiculos)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = item.Placa;
                    dr[1] = item.Contrata;
                    dr[2] = item.Tara;
                    dr[3] = item.Hora_Pesaje;
                    dr[4] = item.Peso2;
                    dr[5] = item.PesoNeto;
                    dt.Rows.Add(dr);
                }
                gv.DataSource = dt;
                gv.DataBind();
            }
            HttpContext context = System.Web.HttpContext.Current;
            context.Response.ClearContent();
            context.Response.Buffer = true;
            context.Response.AddHeader("content-disposition", "attachment; filename=" + filename);
            context.Response.ContentType = "application/ms-excel";
            context.Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            context.Response.Output.Write(sw.ToString());
            context.Response.Flush();
            htw.Close();
            sw.Close();
            context.Response.End();
            return Json(new { successCode = "1" });
        }



        [HttpPost]
        public ActionResult GrabarCapturaPeso(string Fecha, string Turno, string Placa, string Labor_Origen, string Labor_Destino, string Peso, string PesoNeto)
        {
            ExtraccionBalanzaDominio oExtraccionBalanzaDominio = new ExtraccionBalanzaDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            oResponseWeb.Estado = oExtraccionBalanzaDominio.grabarDatos(new ExtraccionBalanzaEntidad
            {
                Fecha = DateTime.Parse(Fecha),
                Turno = Turno,
                Placa = Placa,
                Labor_or = Labor_Origen,
                Labor_de = Labor_Destino,
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