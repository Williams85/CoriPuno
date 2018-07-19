using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class PoligonoEntidad
    {
        public int Id_Poligono { get; set; }
        //public byte Id_Zona { get; set; }
        //public byte Id_Area { get; set; }
        //public byte Id_Mina { get; set; }
        public string Descripcion { get; set; }
        public AreaEntidad Area { get; set; }
        public MinaEntidad Mina { get; set; }
        public ZonaEntidad Zona { get; set; }
    }
}
