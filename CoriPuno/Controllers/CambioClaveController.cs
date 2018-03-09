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
    public class CambioClaveController : Controller
    {
        //
        // GET: /CambioClave/
        public ActionResult Index()
        {
            ViewBag.TituloPagina = "Cambiar Clave";
            return View();
        }
        [HttpPost]
        public ActionResult CambiarClave(UsuarioEntidad entidad)
        {
            UsuarioDominio oUsuarioDominio = new UsuarioDominio();
            ResponseWeb oResponseWeb = new ResponseWeb();
            entidad.Pass_Usuario = Functions.Encriptar(entidad.Pass_Usuario);
            entidad.Id_Usuario = SessionManager.Usuario.Id_Usuario;
            oResponseWeb.Estado = oUsuarioDominio.cambiarClave(entidad);
            if (oResponseWeb.Estado)
                SessionManager.Usuario.Pass_Usuario = entidad.Pass_Usuario;
            return Json(oResponseWeb);
        }


    }
}