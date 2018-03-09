using CoriPuno.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace CoriPuno
{
    public class SessionManager
    {
        public static HttpSessionState Session
        {
            get { return HttpContext.Current.Session; }
        }


        #region "Atributos"
        const string _Usuario = "Usuario";

        #endregion

        #region "Propiedades"
        public static UsuarioEntidad Usuario
        {
            get { return (UsuarioEntidad)Session[_Usuario]; }
            set { Session[_Usuario] = value; }
        }
            
        #endregion
    }
}