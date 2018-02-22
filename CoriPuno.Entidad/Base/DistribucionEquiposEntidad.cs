using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class DistribucionEquiposEntidad
    {
        public DateTime Fecha { get; set; }
        public string Turno { get; set; }
        public string UbicacionInicial { get; set; }
        public string LaborTrabajo { get; set; }
        public string LaborOrigen { get; set; }
        public string LaborDestino { get; set; }
        public string Equipo { get; set; }
        public int IdEquipo { get; set; }

        public string Marca { get; set; }
        public int AñoFabricacion { get; set; }
        public string HoraInicio { get; set; }
        public decimal TotalHorasDeplazadas { get; set; }
        public decimal TotalHorasEfectivas { get; set; }

    }
}
