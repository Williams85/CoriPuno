using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class EquipoDominio
    {
        EquipoRepositorio oEquipoRepositorio = new EquipoRepositorio();
        public List<EquipoEntidad> listarEquipos()
        {
            return oEquipoRepositorio.listarEquipos();
        }
    }
}
