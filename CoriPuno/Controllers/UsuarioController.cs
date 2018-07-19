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
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = "Registrar Usuarios";
            PerfilDominio oPerfilDominio = new PerfilDominio();
            List<PerfilEntidad> ListaPerfiles = new List<PerfilEntidad>();
            ListaPerfiles = oPerfilDominio.ListarActivos();
            ViewBag.ListaPerfiles = ListaPerfiles;
            return View();
        }

        public ActionResult Nuevo()
        {
            ViewBag.TituloPagina = "Registrar Usuarios";
            PerfilDominio oPerfilDominio = new PerfilDominio();
            List<PerfilEntidad> ListaPerfiles = new List<PerfilEntidad>();
            ListaPerfiles = oPerfilDominio.ListarActivos();
            ViewBag.ListaPerfiles = ListaPerfiles;
            return View();
        }

        [HttpPost]
        public ActionResult Edicion(string Codigo)
        {
            ViewBag.TituloPagina = "Registrar Usuarios";
            if (Codigo == null) return RedirectToAction("Index", "Usuario");
            UsuarioDominio oUsuarioDominio = new UsuarioDominio();
            PerfilDominio oPerfilDominio = new PerfilDominio();
            var oUsuario = oUsuarioDominio.obtenerDatosXCodigo(Codigo);
            List<PerfilEntidad> ListaPerfiles = new List<PerfilEntidad>();
            ListaPerfiles = oPerfilDominio.ListarActivos();
            ViewBag.ListaPerfiles = ListaPerfiles;
            return View(oUsuario);
        }

        [HttpPost]
        public ActionResult Buscar(UsuarioEntidad entidad)
        {
            UsuarioDominio oUsuarioDominio = new UsuarioDominio();
            var ListaUsuarios = oUsuarioDominio.obtenerDatosXFiltro(entidad);
            return PartialView("_ResultadosBusqueda", ListaUsuarios);
        }

        [HttpPost]
        public ActionResult Grabar(UsuarioEntidad entidad)
        {
            UsuarioDominio oUsuarioDominio = new UsuarioDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            entidad.Pass_Usuario = Functions.Encriptar(entidad.Pass_Usuario);
            oResponseWeb.Estado = oUsuarioDominio.grabarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }

        [HttpPost]
        public ActionResult Modificar(UsuarioEntidad entidad)
        {
            UsuarioDominio oUsuarioDominio = new UsuarioDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            string menesaje = string.Empty;
            entidad.Pass_Usuario = Functions.Encriptar(entidad.Pass_Usuario);
            if (entidad.Id_Usuario == SessionManager.Usuario.Id_Usuario)
            {
                SessionManager.Usuario.Nom_Usuario = entidad.Nom_Usuario;
                SessionManager.Usuario.Pass_Usuario = entidad.Pass_Usuario;
                SessionManager.Usuario.Perfil_Usuario = entidad.Perfil_Usuario;
            }

            oResponseWeb.Estado = oUsuarioDominio.modificarDatos(entidad, ref menesaje);
            oResponseWeb.Message = menesaje;
            return Json(oResponseWeb);
        }
	}
}