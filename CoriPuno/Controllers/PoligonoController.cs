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
    public class PoligonoController : Controller
    {
        //
        // GET: /Poligono/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = Message.TituloPoligono;
            MinaDominio oMinaDominio = new MinaDominio();
            AreaDominio oAreaDominio = new AreaDominio();
            ZonaDominio oZonaDominio = new ZonaDominio();

            List<MinaEntidad> ListaMinas = new List<MinaEntidad>();
            List<AreaEntidad> ListaAreas = new List<AreaEntidad>();
            List<ZonaEntidad> ListaZonas = new List<ZonaEntidad>();

            ListaMinas = oMinaDominio.Listar();
            ListaAreas = oAreaDominio.Listar(new MinaEntidad
            {
                Id_Mina = 0,
            });

            ListaZonas = oZonaDominio.Listar(new AreaEntidad
            {
                Id_Area = 0,
                Mina = new MinaEntidad
                {
                    Id_Mina = 0,
                }
            });

            ViewBag.ListaMinas = ListaMinas;
            ViewBag.ListaAreas = ListaAreas;
            ViewBag.ListaZonas = ListaZonas;
            return View();
        }

        public ActionResult Nuevo()
        {
            ViewBag.TituloPagina = Message.TituloPoligono;
            MinaDominio oMinaDominio = new MinaDominio();
            AreaDominio oAreaDominio = new AreaDominio();
            ZonaDominio oZonaDominio = new ZonaDominio();

            List<MinaEntidad> ListaMinas = new List<MinaEntidad>();
            List<AreaEntidad> ListaAreas = new List<AreaEntidad>();
            List<ZonaEntidad> ListaZonas = new List<ZonaEntidad>();

            ListaMinas = oMinaDominio.Listar();
            ListaAreas = oAreaDominio.Listar(new MinaEntidad
            {
                Id_Mina = 0,
            });

            ListaZonas = oZonaDominio.Listar(new AreaEntidad
            {
                Id_Area = 0,
                Mina = new MinaEntidad
                {
                    Id_Mina = 0,
                }
            });

            ViewBag.ListaMinas = ListaMinas;
            ViewBag.ListaAreas = ListaAreas;
            ViewBag.ListaZonas = ListaZonas;
            return View();
        }

        [HttpPost]
        public ActionResult Edicion(string Codigo)
        {
            ViewBag.TituloPagina = Message.TituloPoligono;
            if (Codigo == null) return RedirectToAction("Index", "Poligono");

            MinaDominio oMinaDominio = new MinaDominio();
            AreaDominio oAreaDominio = new AreaDominio();
            ZonaDominio oZonaDominio = new ZonaDominio();
            PoligonoDominio oPoligonoDominio = new PoligonoDominio();

            var oPoligono = oPoligonoDominio.obtenerDatosXCodigo(Codigo);


            List<MinaEntidad> ListaMinas = new List<MinaEntidad>();
            List<AreaEntidad> ListaAreas = new List<AreaEntidad>();
            List<ZonaEntidad> ListaZonas = new List<ZonaEntidad>();

            ListaMinas = oMinaDominio.Listar();
            ListaAreas = oAreaDominio.Listar(new MinaEntidad
            {
                Id_Mina = oPoligono.Mina.Id_Mina,
            });

            ListaZonas = oZonaDominio.Listar(new AreaEntidad
            {

                Id_Area = oPoligono.Area.Id_Area,
                Mina = new MinaEntidad
                {
                    Id_Mina = oPoligono.Mina.Id_Mina,
                }
            });

            ViewBag.ListaMinas = ListaMinas;
            ViewBag.ListaAreas = ListaAreas;
            ViewBag.ListaZonas = ListaZonas;

            return View(oPoligono);
        }

        [HttpPost]
        public ActionResult Buscar(PoligonoEntidad entidad)
        {
            PoligonoDominio oPoligonoDominio = new PoligonoDominio();
            var ListaoPoligonos = oPoligonoDominio.obtenerDatosXFiltro(entidad);
            return PartialView("_ResultadosBusqueda", ListaoPoligonos);
        }

        [HttpPost]
        public ActionResult Grabar(PoligonoEntidad entidad)
        {
            PoligonoDominio oPoligonoDominio = new PoligonoDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string mensaje = string.Empty;
            oResponseWeb.Estado = oPoligonoDominio.grabarDatos(entidad, ref mensaje);
            oResponseWeb.Message = mensaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult Modificar(PoligonoEntidad entidad)
        {
            PoligonoDominio oPoligonoDominio = new PoligonoDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string mensaje = string.Empty;
            oResponseWeb.Estado = oPoligonoDominio.modificarDatos(entidad, ref mensaje);
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

        [HttpPost]
        public ActionResult ListarZonas(AreaEntidad entidad)
        {
            ZonaDominio oZonaDominio = new ZonaDominio();
            List<ZonaEntidad> ListaZona = new List<ZonaEntidad>();
            ListaZona = oZonaDominio.Listar(entidad);
            return Json(ListaZona);
        }
    }
}