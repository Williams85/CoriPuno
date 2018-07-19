using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class RechazoProgramacionDominio
    {
        private RechazoProgramacionRepositorio oRechazoProgramacionRepositorio = new RechazoProgramacionRepositorio();

        #region "Metodos No Transaccionales"

        public List<RechazoProgramacionEntidad> obtenerDatosXFiltro(RechazoProgramacionEntidad entidad)
        {
            return oRechazoProgramacionRepositorio.obtenerDatosXFiltro(entidad);
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(RechazoProgramacionEntidad entidad)
        {
            return oRechazoProgramacionRepositorio.grabarDatos(entidad);
        }



        #endregion
    }
}
