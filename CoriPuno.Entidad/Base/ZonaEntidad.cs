using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class ZonaEntidad
    {
        public int Id_Zona { get; set; }
        //public byte Id_Area { get; set; }
        //public byte Id_Mina { get; set; }
        public string Descripcion { get; set; }
        public string Fec_Inicio { get; set; }
        public string Estado { get; set; }
        public MinaEntidad Mina { get; set; }
        public AreaEntidad Area { get; set; }
    }
}
