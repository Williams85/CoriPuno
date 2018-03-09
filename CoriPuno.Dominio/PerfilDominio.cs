using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class PerfilDominio
    {
        PerfilRepositorio oPerfilRepositorio = new PerfilRepositorio();

        public List<PerfilEntidad> ListarActivos()
        {
            return oPerfilRepositorio.ListarActivos();
        }
    }
}
