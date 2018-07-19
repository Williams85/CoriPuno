using CoriPuno.Dominio;
using CoriPuno.Entidad;
using CoriPuno.Utilitario;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CoriPuno.Controllers
{
    [Authentication]
    public class ZonaController : Controller
    {
        //
        // GET: /Zona/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = Message.TituloZona;
            MinaDominio oMinaDominio = new MinaDominio();
            AreaDominio oAreaDominio = new AreaDominio();

            List<MinaEntidad> ListaMinas = new List<MinaEntidad>();
            List<AreaEntidad> ListaAreas = new List<AreaEntidad>();

            ListaMinas = oMinaDominio.Listar();
            ListaAreas = oAreaDominio.Listar(new MinaEntidad
            {
                Id_Mina = 0,
            });

            ViewBag.ListaMinas = ListaMinas;
            ViewBag.ListaAreas = ListaAreas;
            return View();
        }

        public ActionResult Nuevo()
        {
            ViewBag.TituloPagina = Message.TituloZona;
            MinaDominio oMinaDominio = new MinaDominio();
            AreaDominio oAreaDominio = new AreaDominio();

            List<MinaEntidad> ListaMinas = new List<MinaEntidad>();
            List<AreaEntidad> ListaAreas = new List<AreaEntidad>();

            ListaMinas = oMinaDominio.Listar();
            ListaAreas = oAreaDominio.Listar(new MinaEntidad
            {
                Id_Mina = 0,
            });

            ViewBag.ListaMinas = ListaMinas;
            ViewBag.ListaAreas = ListaAreas;
            return View();
        }

        [HttpPost]
        public ActionResult Edicion(string Codigo)
        {
            ViewBag.TituloPagina = Message.TituloZona;
            if (Codigo == null) return RedirectToAction("Index", "Zona");

            MinaDominio oMinaDominio = new MinaDominio();
            AreaDominio oAreaDominio = new AreaDominio();
            ZonaDominio oZonaDominio = new ZonaDominio();

            var oZona = oZonaDominio.obtenerDatosXCodigo(Codigo);


            List<MinaEntidad> ListaMinas = new List<MinaEntidad>();
            List<AreaEntidad> ListaAreas = new List<AreaEntidad>();

            ListaMinas = oMinaDominio.Listar();
            ListaAreas = oAreaDominio.Listar(new MinaEntidad
            {
                Id_Mina = oZona.Mina.Id_Mina,
            });

            ViewBag.ListaMinas = ListaMinas;
            ViewBag.ListaAreas = ListaAreas;

            return View(oZona);
        }

        [HttpPost]
        public ActionResult Buscar(ZonaEntidad entidad)
        {
            ZonaDominio oZonaDominio = new ZonaDominio();
            var ListaZonas = oZonaDominio.obtenerDatosXFiltro(entidad);
            return PartialView("_ResultadosBusqueda", ListaZonas);
        }

        [HttpPost]
        public ActionResult Grabar(ZonaEntidad entidad)
        {
            ZonaDominio oZonaDominio = new ZonaDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string mensaje = string.Empty;
            oResponseWeb.Estado = oZonaDominio.grabarDatos(entidad, ref mensaje);
            oResponseWeb.Message = mensaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult Modificar(ZonaEntidad entidad)
        {
            ZonaDominio oZonaDominio = new ZonaDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string mensaje = string.Empty;
            oResponseWeb.Estado = oZonaDominio.modificarDatos(entidad, ref mensaje);
            oResponseWeb.Message = mensaje;
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
    }
}