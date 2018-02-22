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
    public class RechazoProgramacionRepositorio
    {
        #region "Metodos No Transaccionales"

        public List<RechazoProgramacionEntidad> obtenerDatosXFiltro(RechazoProgramacionEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("RechazoProgramacionListar", cn);
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.Fecha);
                cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.VarChar, 10)).Value = entidad.Turno;
                cmd.CommandType = CommandType.StoredProcedure;
                List<RechazoProgramacionEntidad> ListaMotivoRechazoProgramacion = new List<RechazoProgramacionEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RechazoProgramacionEntidad oRechazoProgramacionEntidad = new RechazoProgramacionEntidad();
                        oRechazoProgramacionEntidad.MotivoRechazo = Reader.GetStringValue(reader, "MotivoRechazo");
                        ListaMotivoRechazoProgramacion.Add(oRechazoProgramacionEntidad);
                    }
                }
                return ListaMotivoRechazoProgramacion;
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

        #region "Metodos Transaccionales"
        public bool grabarDatos(RechazoProgramacionEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("RechazoProgramacionRegistrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.Fecha);
                cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.VarChar, 10)).Value = entidad.Turno;
                cmd.Parameters.Add(new SqlParameter("@MotivoRechazo", SqlDbType.VarChar, 500)).Value = entidad.MotivoRechazo;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = trans;
                if (cmd.ExecuteNonQuery() > 0) estado = true;

                if (estado)
                    trans.Commit();
                else
                    trans.Rollback();

                return estado;
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                return false;
            }
            finally
            {
                Conexion.cerrarConexion(cn);
            }
        }



        #endregion
    }
}
