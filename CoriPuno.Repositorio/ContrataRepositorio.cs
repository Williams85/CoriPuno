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
    public class ContrataRepositorio
    {
        public List<ContrataEntidad> Listar()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mContrata_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<ContrataEntidad> ListaContrata = new List<ContrataEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ContrataEntidad oContrataEntidad = new ContrataEntidad();
                        oContrataEntidad.Id_Contrata = Reader.GetIntValue(reader, "Id_Contrata");
                        oContrataEntidad.Razon_Social = Reader.GetStringValue(reader, "Razon_Social");
                        ListaContrata.Add(oContrataEntidad);
                    }
                }

                return ListaContrata;
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
