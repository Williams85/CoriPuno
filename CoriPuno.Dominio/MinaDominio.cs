using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using CoriPuno.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class MinaDominio
    {
        private MinaRepositorio oMinaRepositorio = new MinaRepositorio();



        #region "Metodos No Transaccionales"

        public List<MinaEntidad> Listar()
        {
            return oMinaRepositorio.Listar();
        }

        public List<MinaEntidad> obtenerDatosXFiltro(MinaEntidad entidad)
        {

            return oMinaRepositorio.obtenerDatosXFiltro(entidad);
        }

        public MinaEntidad obtenerDatosXCodigo(string codigo)
        {
            return oMinaRepositorio.obtenerDatosXCodigo(codigo);
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(MinaEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oMinaRepositorio.validarGrabacionDatos(entidad)) mensaje = Message.ExisteMina;
            else
            {
                if (oMinaRepositorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.GraboMina;
                }
                else
                    mensaje = Message.NoGraboMina;
            }
            return estado;
        }

        public bool modificarDatos(MinaEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oMinaRepositorio.validarModificacionDatos(entidad)) mensaje = Message.ExisteMina;
            else
            {
                if (oMinaRepositorio.modificarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.ModificoMina;
                }
                else
                    mensaje = Message.NoModificoMina;
            }
            return estado;
        }


        #endregion
    }
}
