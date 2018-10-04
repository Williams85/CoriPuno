using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class DProducciontoPlanta_dtmpEntidad
    {
        public int Id_ToPlant { get; set; }
        public string Id_Labor { get; set; }
        public decimal Ley { get; set; }
        public decimal TM_Disponible { get; set; }
        public decimal TM_Optimizado { get; set; }
    }
}
