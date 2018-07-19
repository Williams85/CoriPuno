using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class ProgramacionDiariaCabDominio
    {

        private ProgramacionDiariaCabRepositorio oProgramacionDiariaCabRepositorio = new ProgramacionDiariaCabRepositorio();
        public bool cerrarProgramacion(DateTime fecha, string turno)
        {
            return oProgramacionDiariaCabRepositorio.cerrarProgramacion(fecha, turno);
        }

        public List<ProgramacionDiariaCabEntidad> listarProgramacionPendientes()
        {
            return oProgramacionDiariaCabRepositorio.listarProgramacionPendientes();
        }

        public List<ProgramacionDiariaCabEntidad> ProgramacionesGeneradas()
        {
            var Lista = oProgramacionDiariaCabRepositorio.ProgramacionesGeneradas();
            if (Lista != null && Lista.Count > 0)
            {
                RechazoProgramacionRepositorio oRechazoProgramacionRepositorio = new RechazoProgramacionRepositorio();
                for (int i = 0; i <= Lista.Count - 1; i++)
                {
                    var resultado = oRechazoProgramacionRepositorio.obtenerDatosXFiltro(new RechazoProgramacionEntidad
                    {
                        Fecha = Lista[i].Fecha.ToString("dd/MM/yyyy"),
                        Turno = Lista[i].Turno,
                    });
                    if (resultado != null && resultado.Count > 0)
                        Lista[i].Observado = true;
                    else
                        Lista[i].Observado = false;
                }
            }

            return Lista;
        }

        public bool ProgramacionModificarEstado(DateTime fecha, string turno, string flag)
        {
            return oProgramacionDiariaCabRepositorio.ProgramacionModificarEstado(fecha, turno, flag);
        }

    }
}
