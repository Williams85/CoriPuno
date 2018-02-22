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
    public class ZonaRepositorio
    {
        public List<ZonaEntidad> Listar(AreaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Zona_Listar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Mina", SqlDbType.TinyInt)).Value = entidad.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Id_Area", SqlDbType.TinyInt)).Value = entidad.Id_Area;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ZonaEntidad> ListaZona = new List<ZonaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ZonaEntidad oZonaEntidad = new ZonaEntidad();
                        oZonaEntidad.Id_Zona= Reader.GetTinyIntValue(reader, "Id_Zona");
                        oZonaEntidad.Id_Area = Reader.GetTinyIntValue(reader, "Id_Area");
                        oZonaEntidad.Id_Mina = Reader.GetTinyIntValue(reader, "Id_Mina");
                        oZonaEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        ListaZona.Add(oZonaEntidad);
                    }
                }

                return ListaZona;
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
