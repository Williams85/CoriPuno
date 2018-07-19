using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoriPuno.Models
{
    public class ProgramacionCarguioEntidad
    {
        public int Año { get; set; }
        public string Mes { get; set; }
        public DateTime FInicio { get; set; }
        public DateTime FEjecucion { get; set; }

    }
}