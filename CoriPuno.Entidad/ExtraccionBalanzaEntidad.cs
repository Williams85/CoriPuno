using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class ExtraccionBalanzaEntidad
    {
        public string Turno { get; set; }
        public DateTime Fecha { get; set; }
        public string Placa { get; set; }
        public string Labor_or { get; set; }
        public decimal Peso { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal PesoNeto_A { get; set; }

        public decimal Tara { get; set; }
        public string Hora_Pesaje { get; set; }
        public string IdLabor { get; set; }
        public string Sustento { get; set; }
        public string Autoriza { get; set; }
    }
}
