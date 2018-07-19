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
    public class ComponenteDominio
    {
        private ComponenteRepositorio oComponenteRepositorio = new ComponenteRepositorio();



        #region "Metodos No Transaccionales"


        public List<ComponenteEntidad> obtenerDatosXFiltro(ComponenteEntidad entidad)
        {

            return oComponenteRepositorio.obtenerDatosXFiltro(entidad);
        }

        public ComponenteEntidad obtenerDatosXCodigo(string codigo)
        {
            return oComponenteRepositorio.obtenerDatosXCodigo(codigo);
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(ComponenteEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oComponenteRepositorio.validarGrabacionDatos(entidad)) mensaje = Message.ExisteComponente;
            else
            {
                if (oComponenteRepositorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.GraboComponente;
                }
                else
                    mensaje = Message.NoGraboComponente;
            }
            return estado;
        }

        public bool modificarDatos(ComponenteEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oComponenteRepositorio.validarModificacionDatos(entidad)) mensaje = Message.ExisteComponente;
            else
            {
                if (oComponenteRepositorio.modificarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.ModificoComponente;
                }
                else
                    mensaje = Message.NoModificoComponente;
            }
            return estado;
        }


        #endregion
    }
}
