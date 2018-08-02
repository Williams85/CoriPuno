using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class ProgramacionDiariaDominio
    {
        private ProgramacionDiariaRepositorio oProgramacionDiariaRepositorio = new ProgramacionDiariaRepositorio();
        public ProgramacionDiariaCabEntidad generarProgramacion(DateTime fecha, string turno, decimal leyminima, decimal leymaxima, ref int result)
        {
            ProgramacionDiariaCabEntidad entidad = new ProgramacionDiariaCabEntidad();
            var resultado = oProgramacionDiariaRepositorio.calcularProgramacion(fecha, turno, leyminima, leymaxima, ref result);
            if (resultado)
            {
                entidad = oProgramacionDiariaRepositorio.listarProgramacion(fecha, turno);
            }
            return entidad;
        }

        public List<ProgramacionDiariaEntidad> listarDetalleProgramacion(DateTime fecha, string turno)
        {
            return oProgramacionDiariaRepositorio.listarDetalleProgramacion(fecha, turno);
        }

        public List<ProgramacionDiariaEntidad> listarProgramacionCapturaPeso(DateTime fecha, string turno)
        {
            return oProgramacionDiariaRepositorio.listarProgramacionCapturaPeso(fecha, turno);
        }

        public List<ProgramacionDiariaEntidad> listarConsolidadoCarguio(DateTime fecha)
        {
            return oProgramacionDiariaRepositorio.listarConsolidadoCarguio(fecha);
        }
    }
}
