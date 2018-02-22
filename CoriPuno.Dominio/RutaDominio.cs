using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class RutaDominio
    {
        private RutaRepositorio oRutaRepositorio = new RutaRepositorio();

        #region "Metodos No Transaccionales"

        public List<RutaEntidad> obtenerDatosXFiltro(RutaEntidad entidad)
        {
            return oRutaRepositorio.obtenerDatosXFiltro(entidad);

        }
        public RutaEntidad obtenerDatosXCodigo(int codigo)
        {
            return oRutaRepositorio.obtenerDatosXCodigo(codigo);
        }

        #endregion

        #region "Metodos Transaccionales"

        public bool modificarDatos(RutaEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oRutaRepositorio.modificarDatos(entidad))
            {
                estado = true;
                mensaje = "Ruta modificada correctamente...";
            }
            else
                mensaje = "No se modifico la ruta ...";

            return estado;
        }
        #endregion
    }
}
