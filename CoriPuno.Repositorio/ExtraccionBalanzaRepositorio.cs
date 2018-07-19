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
    public class ExtraccionBalanzaRepositorio
    {

        #region "Metodos No Transaccionales"
        public List<ExtraccionBalanzaEntidad> listarDetalleProgramacion(DateTime fecha, string placa)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("listarlaborespeso", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha_ini", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@placa", SqlDbType.VarChar, 10)).Value = placa;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ExtraccionBalanzaEntidad> listalabores = new List<ExtraccionBalanzaEntidad>();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExtraccionBalanzaEntidad oExtraccionBalanzaEntidad = new ExtraccionBalanzaEntidad();
                    oExtraccionBalanzaEntidad.Turno = Reader.GetStringValue(reader, "turno");
                    oExtraccionBalanzaEntidad.IdLabor = Reader.GetStringValue(reader, "IdLabor");
                    oExtraccionBalanzaEntidad.Labor_or = Reader.GetStringValue(reader, "Labor");
                    oExtraccionBalanzaEntidad.Placa = Reader.GetStringValue(reader, "placa");
                    oExtraccionBalanzaEntidad.Hora_Pesaje = Reader.GetStringValue(reader, "Hora_Pesaje");
                    oExtraccionBalanzaEntidad.Tara = Reader.GetDecimalValue(reader, "Tara");
                    oExtraccionBalanzaEntidad.Peso = Reader.GetDecimalValue(reader, "Peso_fin");
                    oExtraccionBalanzaEntidad.PesoNeto = Reader.GetDecimalValue(reader, "PesoNeto");
                    listalabores.Add(oExtraccionBalanzaEntidad);
                }

                return listalabores;
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

        public List<ExtraccionBalanzaEntidad> listarVehiculos()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("Extraccion_Balanza_ListarVehiculos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<ExtraccionBalanzaEntidad> listalabores = new List<ExtraccionBalanzaEntidad>();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExtraccionBalanzaEntidad oExtraccionBalanzaEntidad = new ExtraccionBalanzaEntidad();
                    oExtraccionBalanzaEntidad.Placa = Reader.GetStringValue(reader, "Placa");
                    listalabores.Add(oExtraccionBalanzaEntidad);
                }

                return listalabores;
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
        public bool grabarDatos(ExtraccionBalanzaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("Extraccion_balanza_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = entidad.Turno;
                cmd.Parameters.Add(new SqlParameter("@labor_or", SqlDbType.VarChar, 10)).Value = entidad.Labor_or;
                cmd.Parameters.Add(new SqlParameter("@placa", SqlDbType.VarChar, 20)).Value = entidad.Placa;
                cmd.Parameters.Add(new SqlParameter("@peso_ini", SqlDbType.Decimal)).Value = entidad.Peso;
                cmd.Parameters.Add(new SqlParameter("@Fecha_fin", SqlDbType.DateTime)).Value = entidad.Fecha;
                cmd.Parameters.Add(new SqlParameter("@PesoNeto", SqlDbType.Decimal)).Value = entidad.PesoNeto;
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
        public bool modificarDatos(ExtraccionBalanzaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("modificacionpesovehiculo", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha_ini", SqlDbType.DateTime)).Value = entidad.Fecha;
                cmd.Parameters.Add(new SqlParameter("@placa", SqlDbType.VarChar, 20)).Value = entidad.Placa;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = entidad.Turno;
                cmd.Parameters.Add(new SqlParameter("@labor", SqlDbType.VarChar, 10)).Value = entidad.Labor_or;
                cmd.Parameters.Add(new SqlParameter("@PesoNeto", SqlDbType.Decimal)).Value = entidad.PesoNeto;
                cmd.Parameters.Add(new SqlParameter("@PesoNeto_A", SqlDbType.Decimal)).Value = entidad.PesoNeto_A;
                cmd.Parameters.Add(new SqlParameter("@sustento", SqlDbType.VarChar,1000)).Value = entidad.Sustento;
                cmd.Parameters.Add(new SqlParameter("@autoriza", SqlDbType.VarChar,100)).Value = entidad.Autoriza;
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
