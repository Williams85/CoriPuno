using CoriPuno.Entidad;
using CoriPuno.Repositorio.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Repositorio
{
    public class EquipoRepositorio
    {
        public List<EquipoEntidad> listarEquipos()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("listarequipos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<EquipoEntidad> listaEquipos = new List<EquipoEntidad>();
                ;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EquipoEntidad oEquipoEntidad = new EquipoEntidad();
                        oEquipoEntidad.IdEquipo = Reader.GetIntValue(reader, "id_equipo");
                        oEquipoEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        oEquipoEntidad.Marca = Reader.GetStringValue(reader, "Marca");
                        oEquipoEntidad.AñoFabricacion = Reader.GetIntValue(reader, "añoFabrica");
                        listaEquipos.Add(oEquipoEntidad);
                    }
                }

                return listaEquipos;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Conexion.cerrarConexion(cn);
            }
        }
    }
}
