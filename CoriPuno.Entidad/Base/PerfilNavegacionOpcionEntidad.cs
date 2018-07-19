using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public class PerfilNavegacionOpcionEntidad
    {
        public int Id_Opcion { get; set; }
        public PerfilNavegacionEntidad PerfilNavegacion { get; set; }
        public PaginaEntidad Pagina { get; set; }
        public bool Activo { get; set; }
    }
}
