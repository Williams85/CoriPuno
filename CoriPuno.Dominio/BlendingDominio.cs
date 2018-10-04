using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class BlendingDominio
    {
        private BlendingRepositorio oBlendingRepositorio = new BlendingRepositorio();
        public DProducciontoPlanta_CabEntidad EjecucionBlending(string FechaProceso, decimal Capacidad, ref string Mensaje)
        {
            DProducciontoPlanta_CabEntidad oDProducciontoPlanta_CabEntidad = new DProducciontoPlanta_CabEntidad();
            try
            {

                if (oBlendingRepositorio.EjecucionBlending(FechaProceso, Capacidad, ref Mensaje))
                {
                    oDProducciontoPlanta_CabEntidad = oBlendingRepositorio.ResultadoEjecBlending(FechaProceso);
                }
                return oDProducciontoPlanta_CabEntidad;
            }
            catch (Exception)
            {
                return oDProducciontoPlanta_CabEntidad;
                throw;
            }
        }

        public int ConfirmarBlending(string FechaProceso)
        {
            return oBlendingRepositorio.ConfirmarBlending(FechaProceso);
        }

        public int EliminarBlending(string FechaProceso)
        {
            return oBlendingRepositorio.EliminarBlending(FechaProceso);
        }
    }
}
