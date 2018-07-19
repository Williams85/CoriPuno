using CoriPuno.Dominio;
using CoriPuno.Entidad;
using CoriPuno.Utilitario;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace CoriPuno.Controllers
{
    public class HomeController : Controller
    {
        [Authentication]
        public ActionResult Index()
        {
            ParametrosDominio oParametrosDominio = new ParametrosDominio();
            LaborDominio oLaborDominio = new LaborDominio();
            var Parametros = oParametrosDominio.Listar();
            int CantidadOrigen = 0;
            int CantidadDestino = 0;
            int ParametroOrigen = Parametros.nLabor;
            int ParametroDestino = Parametros.nLabDest;

            var ListaLaborOrigen = oLaborDominio.obtenerDatosXFiltro(new LaborEntidad
            {
                Codigo = "",
                Descripcion = "",
                Tipo = "OR",
                Estado = "A",
            });

            var ListaLaborDestino = oLaborDominio.obtenerDatosXFiltro(new LaborEntidad
            {
                Codigo = "",
                Descripcion = "",
                Tipo = "DE",
                Estado = "A",
            });

            if (ListaLaborOrigen != null && ListaLaborOrigen.Count > 0)
                CantidadOrigen = ListaLaborOrigen.Count;

            if (ListaLaborDestino != null && ListaLaborDestino.Count > 0)
                CantidadDestino = ListaLaborDestino.Count;

            ViewBag.CantidadOrigen = CantidadOrigen;
            ViewBag.CantidadDestino = CantidadDestino;
            ViewBag.ParametroOrigen = ParametroOrigen;
            ViewBag.ParametroDestino = ParametroDestino;

            return View();
        }

        [HttpPost]
        public ActionResult CalcularProgramacion(decimal LeyMinima, decimal LeyMaxima, string Turno, string FEjecucion)
        {
            ProgramacionDiariaDominio oProgramacionDiariaDominio = new ProgramacionDiariaDominio();
            int result = 0;
            var ListaProgramacion = oProgramacionDiariaDominio.generarProgramacion(DateTime.Parse(FEjecucion), Turno, LeyMinima, LeyMaxima, ref result);
            ViewBag.Mensaje = Functions.obtenerMensajeGeneracionProgramacion(result);
            return PartialView("_ViewProgramacion", ListaProgramacion);
        }

        [HttpPost]
        public ActionResult CerrarProgramacion(string Fecha, string Turno)
        {
            ProgramacionDiariaCabDominio oProgramacionDiariaCabDominio = new ProgramacionDiariaCabDominio();

            var resultado = oProgramacionDiariaCabDominio.cerrarProgramacion(DateTime.Parse(Fecha), Turno);
            return Json(resultado);
        }

        [HttpPost]
        public ActionResult Login(string Nom_Usuario, string Pass_Usuario)
        {
            if (ModelState.IsValid && ((Nom_Usuario != null || Nom_Usuario != "") || (Pass_Usuario != null || Pass_Usuario != "")))
            {
                UsuarioDominio oUsuarioDominio = new UsuarioDominio();
                var entidad = oUsuarioDominio.validarUsuario(new UsuarioEntidad
                {
                    Nom_Usuario = Nom_Usuario,
                    Pass_Usuario = Functions.Encriptar(Pass_Usuario),

                });
                if (entidad != null)
                {
                    FormsAuthentication.SetAuthCookie(Nom_Usuario, false);
                    SessionManager.Usuario = entidad;
                    return RedirectToAction("Index", "Home");
                }
                else
                    return Redirect("~/Login/Login.aspx");

            }
            else
                return Redirect("~/Login/Login.aspx");
        }

        [HttpPost]
        public ActionResult ValidarLogin(string Nom_Usuario, string Pass_Usuario)
        {
            ResponseWeb oResponseWeb = new ResponseWeb() { Message = Message.MsgErrUserPassword, Estado = false };
            if (ModelState.IsValid && ((Nom_Usuario != null || Nom_Usuario != "") || (Pass_Usuario != null || Pass_Usuario != "")))
            {
                UsuarioDominio oUsuarioDominio = new UsuarioDominio();
                var entidad = oUsuarioDominio.validarUsuario(new UsuarioEntidad
                {
                    Nom_Usuario = Nom_Usuario,
                    Pass_Usuario = Functions.Encriptar(Pass_Usuario),

                });
                if (entidad != null && (entidad.ListaPerfilNavegacion != null && entidad.ListaPerfilNavegacion.Count > 0) 
                    && (entidad.ListaPerfilNavegacion[0].ListaPerfilNavegacionOpcion != null && entidad.ListaPerfilNavegacion[0].ListaPerfilNavegacionOpcion.Count > 0))
                    oResponseWeb.Estado = true;
                else
                    oResponseWeb.Message = Message.MsgErrUserPassword;
            }
            else
                oResponseWeb.Message = Message.MsgErrUserPassword;

            return Json(oResponseWeb);
        }

        public ActionResult Autenticar()
        {
            return Redirect("~/Login/Login.aspx");
        }

        [Authentication]
        public ActionResult End()
        {
            Session.Abandon();
            return Redirect("~/Login/Login.aspx");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}