using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class VehiculoEntidad
    {
        public int IdVehiculo { get; set; }
        public string Placa { get; set; }
        public string Contrata { get; set; }
        public decimal Tara { get; set; }
        public decimal Capacidad { get; set; }
        public decimal PesoNeto { get; set; }
        public decimal Peso { get { return this.PesoNeto + this.Tara; } }
        public decimal Peso2 { get; set; }
        public string Hora_Pesaje { get; set; }

    }
}
