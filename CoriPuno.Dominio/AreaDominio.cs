using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class AreaDominio
    {
        private AreaRepositorio oAreaRepositorio = new AreaRepositorio();
        public List<AreaEntidad> Listar(MinaEntidad entidad)
        {
            return oAreaRepositorio.Listar(entidad);
        }
    }
}
