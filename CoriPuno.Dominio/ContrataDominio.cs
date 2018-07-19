using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class ContrataDominio
    {
        ContrataRepositorio oContrataRepositorio = new ContrataRepositorio();
        public List<ContrataEntidad> Listar()
        {
            return oContrataRepositorio.Listar();
        }
    }
}
