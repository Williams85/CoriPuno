using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Entidad
{
    public partial class UsuarioEntidad
    {
        public short Id_Usuario { get; set; }
        public PerfilEntidad Perfil { get; set; }
        public string Nom_Usuario { get; set; }
        public string Pass_Usuario { get; set; }
        public string Perfil_Usuario { get; set; }
        public bool Activo { get; set; }
    }
}
