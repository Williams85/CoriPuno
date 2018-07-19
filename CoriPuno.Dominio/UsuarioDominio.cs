using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class UsuarioDominio
    {
        private UsuarioRepositorio oUsuarioRepositorio = new UsuarioRepositorio();



        #region "Metodos No Transaccionales"
        public UsuarioEntidad validarUsuario(UsuarioEntidad entidad)
        {
            return oUsuarioRepositorio.validarUsuario(entidad);
        }
        public List<UsuarioEntidad> obtenerDatosXFiltro(UsuarioEntidad entidad)
        {

            return oUsuarioRepositorio.obtenerDatosXFiltro(entidad);
        }
        public UsuarioEntidad obtenerDatosXCodigo(string codigo)
        {
            return oUsuarioRepositorio.obtenerDatosXCodigo(codigo);
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(UsuarioEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oUsuarioRepositorio.validarGrabacionDatos(entidad)) mensaje = "El usuario ingresado existe...";
            else
            {
                if (oUsuarioRepositorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = "Usuario registrado correctamente...";
                }
                else
                    mensaje = "No se registro el usuario...";
            }
            return estado;
        }

        public bool modificarDatos(UsuarioEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oUsuarioRepositorio.validarModificacionDatos(entidad)) mensaje = "El usuario ingresada existe...";
            else
            {
                if (oUsuarioRepositorio.modificarDatos(entidad))
                {
                    estado = true;
                    mensaje = "Usuario modificado correctamente...";
                }
                else
                    mensaje = "No se modifico el usuario ...";
            }
            return estado;
        }
        public bool cambiarClave(UsuarioEntidad entidad)
        {

            return oUsuarioRepositorio.cambiarClave(entidad);
        }


        #endregion
    }
}
