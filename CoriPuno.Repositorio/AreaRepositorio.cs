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
    public class AreaRepositorio
    {
        public List<AreaEntidad> Listar(MinaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Area_Listar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Mina", SqlDbType.TinyInt)).Value = entidad.Id_Mina;
                cmd.CommandType = CommandType.StoredProcedure;
                List<AreaEntidad> ListaArea = new List<AreaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        AreaEntidad oAreaEntidad = new AreaEntidad();
                        oAreaEntidad.Id_Area = Reader.GetTinyIntValue(reader, "Id_Area");
                        oAreaEntidad.Id_Mina = Reader.GetTinyIntValue(reader, "Id_Mina");
                        oAreaEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        ListaArea.Add(oAreaEntidad);
                    }
                }

                return ListaArea;
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
