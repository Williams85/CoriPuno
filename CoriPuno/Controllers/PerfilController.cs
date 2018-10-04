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
    public class PerfilController : Controller
    {
        //
        // GET: /Perfil/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = Message.TituloFormIndicadores;
            return View();
        }

        [HttpPost]
        public ActionResult Buscar(PerfilEntidad entidad)
        {
            PerfilDominio oPerfilDominio = new PerfilDominio();
            var ListaoPerfiles = oPerfilDominio.Filtrar(entidad.Nom_Perfil);
            return PartialView("_ResultadosBusqueda", ListaoPerfiles);
        }
	}
}