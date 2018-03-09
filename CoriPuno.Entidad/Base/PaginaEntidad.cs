using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class PaginaEntidad
    {
        public byte Id_Pagina { get; set; }
        public string Nom_Pagina { get; set; }
        public string Url_Pagina { get; set; }
        public bool Activo { get; set; }
    }
}
