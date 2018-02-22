using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class ParametrosDominio
    {
        private ParametrosRepositorio oParametrosRepositorio = new ParametrosRepositorio();

        public ParametrosEntidad Listar()
        {
            return oParametrosRepositorio.Listar();
        }
    }
}
