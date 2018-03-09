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
    public class LaborController : Controller
    {
        // GET: Labor
        public ActionResult Index()
        {
            ViewBag.TituloPagina = "Registrar Labores";
            return View();
        }

        public ActionResult Nuevo()
        {
            ViewBag.TituloPagina = "Registrar Labores";
            MinaDominio oMinaDominio = new MinaDominio();
            AreaDominio oAreaDominio = new AreaDominio();
            ZonaDominio oZonaDominio = new ZonaDominio();

            List<MinaEntidad> ListaMina = new List<MinaEntidad>();
            List<AreaEntidad> ListaArea = new List<AreaEntidad>();
            List<ZonaEntidad> ListaZona = new List<ZonaEntidad>();

            ListaMina = oMinaDominio.Listar();
            if (ListaMina != null && ListaMina.Count > 0)
                ListaArea = oAreaDominio.Listar(ListaMina[0]);

            if (ListaArea != null && ListaArea.Count > 0)
                ListaZona = oZonaDominio.Listar(ListaArea[0]);

            ViewBag.ListaMina = ListaMina;
            ViewBag.ListaArea = ListaArea;
            ViewBag.ListaZona = ListaZona;

            return View();
        }

        [HttpPost]
        public ActionResult Edicion(string Codigo)
        {
            ViewBag.TituloPagina = "Registrar Labores";
            if (Codigo == null) return RedirectToAction("Index", "Labor");
            Dictionary<string, string> ListaTipo = new Dictionary<string, string>();
            ListaTipo.Add("OR", "Origen");
            ListaTipo.Add("DE", "Destino");
            ViewBag.ListaTipo = ListaTipo;
            LaborDominio oLaborDominio = new LaborDominio();
            var oLaborEntidad = oLaborDominio.obtenerDatosXCodigo(Codigo);

            MinaDominio oMinaDominio = new MinaDominio();
            AreaDominio oAreaDominio = new AreaDominio();
            ZonaDominio oZonaDominio = new ZonaDominio();

            List<MinaEntidad> ListaMina = new List<MinaEntidad>();
            List<AreaEntidad> ListaArea = new List<AreaEntidad>();
            List<ZonaEntidad> ListaZona = new List<ZonaEntidad>();

            ListaMina = oMinaDominio.Listar();
            if (ListaMina != null && ListaMina.Count > 0)
                ListaArea = oAreaDominio.Listar(new MinaEntidad
                {
                    Id_Mina = oLaborEntidad.Id_Mina,
                });

            if (ListaArea != null && ListaArea.Count > 0)
                ListaZona = oZonaDominio.Listar(new AreaEntidad
                {
                    Id_Area = oLaborEntidad.Id_Area,
                    Mina = new MinaEntidad
                    {
                        Id_Mina=oLaborEntidad.Id_Mina
                    }

                });


            ViewBag.ListaMina = ListaMina;
            ViewBag.ListaArea = ListaArea;
            ViewBag.ListaZona = ListaZona;

            return View(oLaborEntidad);
        }

        [HttpPost]
        public ActionResult BuscarLabor(LaborEntidad entidad)
        {
            LaborDominio oLaborDominio = new LaborDominio();
            var ListaLabor = oLaborDominio.obtenerDatosXFiltro(entidad);
            Session["ListaLabor"] = ListaLabor;
            return PartialView("_ResultadosBusqueda", ListaLabor);
        }

        [HttpPost]
        public ActionResult MostrarTotalOrigen()
        {
            var ListaLabor = ((List<LaborEntidad>)Session["ListaLabor"]).Where(x => x.Tipo == "OR").ToList();
            int cantidad = 0;
            if (ListaLabor != null && ListaLabor.Count > 0)
                cantidad = ListaLabor.Count;
            return Json(cantidad);
        }

        [HttpPost]
        public ActionResult MostrarTotalDestino()
        {
            var ListaLabor = ((List<LaborEntidad>)Session["ListaLabor"]).Where(x => x.Tipo == "DE").ToList();
            int cantidad = 0;
            if (ListaLabor != null && ListaLabor.Count > 0)
                cantidad = ListaLabor.Count;

            return Json(cantidad);
        }

        [HttpPost]
        public ActionResult CerrarLabor(string codigo)
        {
            LaborDominio oLaborDominio = new LaborDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            oResponseWeb.Estado = oLaborDominio.cerrarLabor(codigo);
            oResponseWeb.Message = "Labor cerrada...";
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult AbrirLabor(string codigo)
        {
            LaborDominio oLaborDominio = new LaborDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            oResponseWeb.Estado = oLaborDominio.cerrarLabor(codigo);
            oResponseWeb.Message = "Labor abierta...";
            return Json(oResponseWeb);
        }


        [HttpPost]
        public ActionResult GrabarLabor(LaborEntidad entidad)
        {
            LaborDominio oLaborDominio = new LaborDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            oResponseWeb.Estado = oLaborDominio.grabarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult ModificarLabor(LaborEntidad entidad)
        {
            LaborDominio oLaborDominio = new LaborDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            oResponseWeb.Estado = oLaborDominio.modificarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult ListarAreas(MinaEntidad entidad)
        {
            AreaDominio oAreaDominio = new AreaDominio();
            List<AreaEntidad> ListaArea = new List<AreaEntidad>();
            ListaArea = oAreaDominio.Listar(entidad);

            return Json(ListaArea);
        }

        [HttpPost]
        public ActionResult ListarZonas(AreaEntidad entidad)
        {
            ZonaDominio oZonaDominio = new ZonaDominio();
            List<ZonaEntidad> ListaZona = new List<ZonaEntidad>();
            ListaZona = oZonaDominio.Listar(entidad);
            return Json(ListaZona);
        }

        [HttpPost]
        public ActionResult ListarPoligonos(ZonaEntidad entidad)
        {
            PoligonoDominio oPoligonoDominio = new PoligonoDominio();
            List<PoligonoEntidad> ListaPoligono = new List<PoligonoEntidad>();
            ListaPoligono = oPoligonoDominio.Listar(entidad);

            return Json(ListaPoligono);
        }

    }
}