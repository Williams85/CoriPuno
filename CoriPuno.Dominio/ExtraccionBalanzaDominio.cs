using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class ExtraccionBalanzaDominio
    {
        private ExtraccionBalanzaRepositorio oExtraccionBalanzaReposotirio = new ExtraccionBalanzaRepositorio();

        #region "Metodos No Transaccionales"
        public List<ExtraccionBalanzaEntidad> listarDetalleProgramacion(DateTime fecha, string placa)
        {
            return oExtraccionBalanzaReposotirio.listarDetalleProgramacion(fecha, placa);
        }
        public List<ExtraccionBalanzaEntidad> listarVehiculos()
        {
            return oExtraccionBalanzaReposotirio.listarVehiculos();
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(ExtraccionBalanzaEntidad entidad)
        {
            return oExtraccionBalanzaReposotirio.grabarDatos(entidad);
        }

        public bool modificarDatos(ExtraccionBalanzaEntidad entidad)
        {
            return oExtraccionBalanzaReposotirio.modificarDatos(entidad);
        }

        #endregion
    }
}
