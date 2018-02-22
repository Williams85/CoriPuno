using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class MinaDominio
    {
        private MinaRepositorio oMinaRepositorio = new MinaRepositorio();

        public List<MinaEntidad> Listar()
        {
            return oMinaRepositorio.Listar();
        }
    }
}
