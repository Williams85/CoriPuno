using CoriPuno.Entidad;
using System;
using System.Collections.Generic;

namespace CoriPuno.Dominio
{
    public class PaqueteDominio
    {
        PaqueteRepositorio oPaqueteRepositorio = new PaqueteRepositorio();

        #region "Metodos No Transaccionales"

        public List<PaqueteEntidad> ListarActivos()
        {
            try
            {
                return oPaqueteRepositorio.ListarActivos();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
