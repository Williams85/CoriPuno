using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Utilitario
{
    public class Message
    {

        #region "Titulo"
        public const string TituloMina = "Registrar Minas";
        public const string TituloZona = "Registrar Zonas";
        public const string TituloPoligono = "Registrar Poligonos";
        #endregion

        #region "Login"
        public const string MsgErrUserPassword = "El usuario o la contraseña es incorrecta.";
        #endregion

        #region "Mantenimiento Poligono"
        public const string GraboPoligono = "Se grabó el poligono...";
        public const string NoGraboPoligono = "No se grabó el poligono...";
        public const string ModificoPoligono = "Se modificó el poligono...";
        public const string NoModificoPoligono = "No se modificó el poligono...";
        public const string ExistePoligono = "El poligono ingresada ya existe...";
        #endregion

        #region "Mantenimiento Zona"
        public const string GraboZona = "Se grabó la zona...";
        public const string NoGraboZona = "No se grabó la zona...";
        public const string ModificoZona = "Se modificó la zona...";
        public const string NoModificoZona = "No se modificó la zona...";
        public const string ExisteZona = "La zona ingresada ya existe...";
        #endregion

        #region "Mantenimiento Mina"
        public const string GraboMina = "Se grabó la mina...";
        public const string NoGraboMina = "No se grabó la mina...";
        public const string ModificoMina = "Se modificó la mina...";
        public const string NoModificoMina = "No se modificó la mina...";
        public const string ExisteMina = "La mina ingresada ya existe...";
        #endregion

        #region "Mantenimiento Usuario"
        public const string GraboUsuario = "Se grabó el usuario...";
        public const string NoGraboUsuario = "No se grabó el usuario...";
        public const string ModificoUsuario = "Se modificó el usuario...";
        public const string NoModificoUsuario = "No se modificó el usuario...";
        public const string ExisteUsuario = "El usuario ingresada ya existe...";
        #endregion



    }
}
