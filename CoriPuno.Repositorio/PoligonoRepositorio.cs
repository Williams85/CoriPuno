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
    public class PoligonoRepositorio
    {
        public List<PoligonoEntidad> Listar(ZonaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Poligono_Listar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Mina", SqlDbType.TinyInt)).Value = entidad.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Id_Area", SqlDbType.TinyInt)).Value = entidad.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_Zona", SqlDbType.TinyInt)).Value = entidad.Id_Zona;

                cmd.CommandType = CommandType.StoredProcedure;
                List<PoligonoEntidad> ListaPoligono = new List<PoligonoEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PoligonoEntidad oPoligonoEntidad = new PoligonoEntidad();
                        oPoligonoEntidad.Id_Poligono = Reader.GetTinyIntValue(reader, "Id_Poligono");
                        oPoligonoEntidad.Id_Area = Reader.GetTinyIntValue(reader, "Id_Zona");
                        oPoligonoEntidad.Id_Area = Reader.GetTinyIntValue(reader, "Id_Area");
                        oPoligonoEntidad.Id_Mina = Reader.GetTinyIntValue(reader, "Id_Mina");
                        oPoligonoEntidad.Descripcion = Reader.GetStringValue(reader, "Descripcion");
                        ListaPoligono.Add(oPoligonoEntidad);
                    }
                }

                return ListaPoligono;
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
