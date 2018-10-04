using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;

namespace CoriPuno.Dominio
{
    public class PaginaDominio
    {

        PaginaRepositorio oPaginaRepositorio = new PaginaRepositorio();

        #region "Metodos No Transaccionales"

        public List<PaginaEntidad> ListarActivos()
        {
            try
            {
                return oPaginaRepositorio.ListarActivos();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
