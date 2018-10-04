using CoriPuno.Entidad;
using CoriPuno.Repositorio.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class PaqueteRepositorio
    {
        #region "Metodos No Transaccionales"

        public List<PaqueteEntidad> ListarActivos()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mPaquete_Listar", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                List<PaqueteEntidad> ListaPaquete = new List<PaqueteEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PaqueteEntidad oPaqueteEntidad = new PaqueteEntidad();
                        oPaqueteEntidad.Id_Paquete = Reader.GetTinyIntValue(reader, "Id_Paquete");
                        oPaqueteEntidad.Nom_Paquete = Reader.GetStringValue(reader, "Nom_Paquete");
                        ListaPaquete.Add(oPaqueteEntidad);
                    }
                }

                return ListaPaquete;
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

        #endregion
    }
}
