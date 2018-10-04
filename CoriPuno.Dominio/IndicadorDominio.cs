using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class IndicadorDominio
    {
        private IndicadorRepositorio oIndicadorRepositorio = new IndicadorRepositorio();



        #region "Metodos No Transaccionales"
        public List<IndicadorEntidad> obtenerDatosXFiltro(IndicadorEntidad entidad)
        {

            return oIndicadorRepositorio.obtenerDatosXFiltro(entidad);
        }
        public IndicadorEntidad obtenerDatosXCodigo(string codigo)
        {
            return oIndicadorRepositorio.obtenerDatosXCodigo(codigo);
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(IndicadorEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oIndicadorRepositorio.validarGrabacionDatos(entidad)) mensaje = "La Formulación del indicador ingresado existe...";
            else
            {
                if (oIndicadorRepositorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = "Formulación de indicador registrado correctamente...";
                }
                else
                    mensaje = "No se registro la formulación del indicador...";
            }
            return estado;
        }

        public bool modificarDatos(IndicadorEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oIndicadorRepositorio.validarModificacionDatos(entidad)) mensaje = "La Formulación del indicador ingresado existe...";
            else
            {
                if (oIndicadorRepositorio.modificarDatos(entidad))
                {
                    estado = true;
                    mensaje = "Formulación de indicador modificado correctamente...";
                }
                else
                    mensaje = "No se modifico la formulación del indicador...";
            }
            return estado;
        }

        #endregion
    }
}
