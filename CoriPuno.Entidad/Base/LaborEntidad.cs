using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public partial class LaborEntidad
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public decimal Ley { get; set; }
        public decimal Capacidad { get; set; }
        public decimal PorRoca { get; set; }
        public decimal AReaManiObra { get; set; }
        public string FechaApertura { get; set; }
        public string FechaLey { get; set; }
        public byte Id_Poligono { get; set; }
        public byte Id_Zona { get; set; }
        public byte Id_Area { get; set; }
        public byte Id_Mina { get; set; }
        public string Estado { get; set; }

    }
}
