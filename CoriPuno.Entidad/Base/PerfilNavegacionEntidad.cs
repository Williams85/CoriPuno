using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public partial class PerfilNavegacionEntidad
    {
        public int Id_Navegacion { get; set; }
        public PerfilEntidad Perfil { get; set; }
        public PaqueteEntidad Paquete { get; set; }
        public bool Activo { get; set; }
    }
}
