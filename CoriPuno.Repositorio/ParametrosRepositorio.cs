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
    public class ParametrosRepositorio
    {
        public ParametrosEntidad Listar()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("Parametros_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                ParametrosEntidad oParametrosEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oParametrosEntidad = new ParametrosEntidad();
                        oParametrosEntidad.nLabor = Reader.GetTinyIntValue(reader, "nLabor");
                        oParametrosEntidad.nLabDest = Reader.GetTinyIntValue(reader, "nLabDest");
                    }
                }
                return oParametrosEntidad;
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
