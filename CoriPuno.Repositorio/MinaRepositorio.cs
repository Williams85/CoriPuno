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
    public class MinaRepositorio
    {
        public List<MinaEntidad> Listar()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Mina_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<MinaEntidad> ListaMina = new List<MinaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MinaEntidad oMinaEntidad = new MinaEntidad();
                        oMinaEntidad.Id_Mina = Reader.GetTinyIntValue(reader, "Id_Mina");
                        oMinaEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        ListaMina.Add(oMinaEntidad);
                    }
                }

                return ListaMina;
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
