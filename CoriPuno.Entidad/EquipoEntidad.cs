using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class EquipoEntidad
    {
        public int IdEquipo { get; set; }
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public int AñoFabricacion { get; set; }
        public string Equipo { get { return this.Descripcion + " " + this.Marca + " " + this.AñoFabricacion.ToString(); } }

    }
}
