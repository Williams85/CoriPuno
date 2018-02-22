using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class PoligonoDominio
    {
        private PoligonoRepositorio oPoligonoRepositorio = new PoligonoRepositorio();

        public List<PoligonoEntidad> Listar(ZonaEntidad entidad)
        {
            return oPoligonoRepositorio.Listar(entidad);
        }
    }
}
