using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public partial class RutaEntidad
    {
        public int IdRuta { get; set; }
        public string IdOrigen { get; set; }
        public string IdDestino { get; set; }
        public decimal Distancia { get; set; }
        public int Factor { get; set; }

    }
}
