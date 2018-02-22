using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class DistribucionEquiposDominio
    {
        private DistribucionEquiposRepositorio oDistribucionEquiposRepositorio = new DistribucionEquiposRepositorio();
        public List<DistribucionEquiposEntidad> distribuirEquiposProgramacion(DateTime fecha, string turno)
        {
            List<DistribucionEquiposEntidad> lista = new List<DistribucionEquiposEntidad>();
            var resultado = oDistribucionEquiposRepositorio.distribuirEquipos(fecha, turno);
            if (resultado)
            {
                lista = oDistribucionEquiposRepositorio.listarProgramacionEquipos(fecha, turno);
            }
            return lista;
        }
        public List<DistribucionEquiposEntidad> listarEquiposProgramacion(DateTime fecha, string turno)
        {
            return oDistribucionEquiposRepositorio.listarProgramacionEquipos(fecha, turno); ;
        }

        public bool asignarEquipo(DateTime fecha, string turno, string laboror, string laborde, int idequipo)
        {
            return oDistribucionEquiposRepositorio.asignarEquipo(fecha, turno, laboror, laborde, idequipo);
        }

        public bool cerrarProgramacionEquipos(DateTime fecha, string turno)
        {
            return oDistribucionEquiposRepositorio.cerrarProgramacionEquipos(fecha, turno);
        }
    }
}
