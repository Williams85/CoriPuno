using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class AreaEntidad
    {
        public int Id_Area { get; set; }
        //public int Id_Mina { get; set; }
        public string Descripcion { get; set; }
        public MinaEntidad Mina { get; set; }
    }
}
