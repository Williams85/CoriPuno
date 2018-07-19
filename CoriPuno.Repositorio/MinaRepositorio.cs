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


        #region "Metodos No Transaccionales"
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
        public List<MinaEntidad> obtenerDatosXFiltro(MinaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Mina_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 250)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<MinaEntidad> ListaMina = new List<MinaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MinaEntidad oMinaEntidad = new MinaEntidad();
                        oMinaEntidad.Id_Mina = Reader.GetIntValue(reader, "Id_Mina");
                        oMinaEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        oMinaEntidad.Fec_Inicio = Reader.GetDateTimeValue(reader, "Fec_Inicio").ToString("dd/MM/yyyy");
                        oMinaEntidad.Fec_Fin = Reader.GetDateTimeValue(reader, "Fec_Fin").ToString("dd/MM/yyyy");
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
        public MinaEntidad obtenerDatosXCodigo(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Mina_BuscarxId", cn);
                cmd.Parameters.Add(new SqlParameter("@id_mina", SqlDbType.Int)).Value = Int32.Parse(codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                MinaEntidad oMinaEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oMinaEntidad = new MinaEntidad();
                        oMinaEntidad.Id_Mina = Reader.GetIntValue(reader, "Id_Mina");
                        oMinaEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        oMinaEntidad.Fec_Inicio = Reader.GetDateTimeValue(reader, "Fec_Inicio").ToString("dd/MM/yyyy");
                        oMinaEntidad.Fec_Fin = Reader.GetDateTimeValue(reader, "Fec_Fin").ToString("dd/MM/yyyy");
                    }
                }
                return oMinaEntidad;
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
        public bool validarModificacionDatos(MinaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Mina_ValidarModificacion", cn);
                cmd.Parameters.Add(new SqlParameter("@id_mina", SqlDbType.Int)).Value = entidad.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) estado = true;

                return estado;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conexion.cerrarConexion(cn);
            }
        }
        public bool validarGrabacionDatos(MinaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Mina_ValidarGrabacion", cn);
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
                cmd.CommandType = CommandType.StoredProcedure;
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read()) estado = true;

                return estado;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Conexion.cerrarConexion(cn);
            }
        }
        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(MinaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Mina_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = entidad.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Fec_inicio", SqlDbType.DateTime)).Value = entidad.Fec_Inicio;
                cmd.Parameters.Add(new SqlParameter("@Fec_fin", SqlDbType.DateTime)).Value = entidad.Fec_Fin;
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

        public bool modificarDatos(MinaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Mina_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Mina", SqlDbType.Int)).Value = entidad.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = entidad.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Fec_inicio", SqlDbType.DateTime)).Value = entidad.Fec_Inicio;
                cmd.Parameters.Add(new SqlParameter("@Fec_fin", SqlDbType.DateTime)).Value = entidad.Fec_Fin;
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
