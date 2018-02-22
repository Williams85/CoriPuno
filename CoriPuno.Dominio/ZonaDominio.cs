using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class ZonaDominio
    {
        private ZonaRepositorio oZonaRepositorio = new ZonaRepositorio();

        public List<ZonaEntidad> Listar(AreaEntidad entidad)
        {
            return oZonaRepositorio.Listar(entidad);
        }
    }
}
