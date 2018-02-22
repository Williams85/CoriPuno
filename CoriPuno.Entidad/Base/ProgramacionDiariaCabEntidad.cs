using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public partial class ProgramacionDiariaCabEntidad
    {
        public int IdProgramacion { get; set; }
        public DateTime Fecha { get; set; }
        public string Turno { get; set; }
        public decimal LeyMaxima { get; set; }
        public decimal LeyMinima { get; set; }
        public decimal CostoAproximado { get; set; }
        public decimal LeyPromedio { get; set; }
        public int Año { get; set; }
        public string Mes { get; set; }
        public string Estado { get; set; }
        public List<ProgramacionDiariaEntidad> DetalleProgramacion { get; set; }
    }
}
