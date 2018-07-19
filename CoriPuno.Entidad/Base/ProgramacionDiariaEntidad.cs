using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class ProgramacionDiariaEntidad
    {
        public int Año { get; set; }
        public string Mes { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaEjecucion { get; set; }
        public string Turno { get; set; }
        public string LaborOrigen { get; set; }
        public string LaborDestino { get; set; }
        public string IdOrigen { get; set; }
        public string IdDestino { get; set; }
        public decimal Ley { get; set; }
        public decimal CapacidadMaxima { get; set; }
        public decimal Distancia { get; set; }
        public decimal ToneladasProcesar { get; set; }
        public decimal ToneladasEjecucion { get; set; }

        public int Id_Prog { get; set; }


    }
}
