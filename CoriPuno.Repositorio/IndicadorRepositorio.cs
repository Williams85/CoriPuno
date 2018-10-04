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
    public class IndicadorRepositorio
    {

        #region "Metodos No Transaccionales"

        public List<IndicadorEntidad> obtenerDatosXFiltro(IndicadorEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Indicadores_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Nom_Indicador", SqlDbType.VarChar, 100)).Value = (entidad.Nom_Indicador != null ? entidad.Nom_Indicador : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<IndicadorEntidad> ListaIndicador = new List<IndicadorEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        IndicadorEntidad oIndicadorEntidad = new IndicadorEntidad();
                        oIndicadorEntidad.Id_Indicador = Reader.GetIntValue(reader, "Id_Indicador");
                        oIndicadorEntidad.Var_Indicador = Reader.GetStringValue(reader, "Var_Indicador");
                        oIndicadorEntidad.Nom_Indicador = Reader.GetStringValue(reader, "Nom_Indicador");
                        oIndicadorEntidad.Ope_1 = Reader.GetStringValue(reader, "Ope_1");
                        oIndicadorEntidad.Ope_2 = Reader.GetStringValue(reader, "Ope_2");
                        oIndicadorEntidad.Ope_3 = Reader.GetStringValue(reader, "Ope_3");
                        oIndicadorEntidad.Ope_4 = Reader.GetStringValue(reader, "Ope_4");
                        oIndicadorEntidad.Ope_5 = Reader.GetStringValue(reader, "Ope_5");
                        oIndicadorEntidad.Ope_6 = Reader.GetStringValue(reader, "Ope_6");
                        oIndicadorEntidad.Ope_7 = Reader.GetStringValue(reader, "Ope_7");
                        oIndicadorEntidad.Ope_8 = Reader.GetStringValue(reader, "Ope_8");
                        oIndicadorEntidad.Ope_9 = Reader.GetStringValue(reader, "Ope_9");
                        oIndicadorEntidad.Ope_10 = Reader.GetStringValue(reader, "Ope_10");
                        oIndicadorEntidad.Ope_11 = Reader.GetStringValue(reader, "Ope_11");
                        oIndicadorEntidad.Ope_12 = Reader.GetStringValue(reader, "Ope_12");
                        oIndicadorEntidad.Ope_13 = Reader.GetStringValue(reader, "Ope_13");
                        oIndicadorEntidad.Ope_14 = Reader.GetStringValue(reader, "Ope_14");
                        oIndicadorEntidad.Ope_15 = Reader.GetStringValue(reader, "Ope_15");
                        oIndicadorEntidad.Ope_16 = Reader.GetStringValue(reader, "Ope_16");
                        oIndicadorEntidad.Ope_17 = Reader.GetStringValue(reader, "Ope_17");
                        oIndicadorEntidad.Ope_18 = Reader.GetStringValue(reader, "Ope_18");
                        ListaIndicador.Add(oIndicadorEntidad);
                    }
                }
                return ListaIndicador;
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
        public IndicadorEntidad obtenerDatosXCodigo(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Indicadores_BuscarxId", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_indicador", SqlDbType.Int)).Value = Int16.Parse(codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                IndicadorEntidad oIndicadorEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oIndicadorEntidad = new IndicadorEntidad();
                        oIndicadorEntidad.Id_Indicador = Reader.GetIntValue(reader, "Id_Indicador");
                        oIndicadorEntidad.Var_Indicador = Reader.GetStringValue(reader, "Var_Indicador");
                        oIndicadorEntidad.Nom_Indicador = Reader.GetStringValue(reader, "Nom_Indicador");
                        oIndicadorEntidad.Ope_1 = Reader.GetStringValue(reader, "Ope_1");
                        oIndicadorEntidad.Ope_2 = Reader.GetStringValue(reader, "Ope_2");
                        oIndicadorEntidad.Ope_3 = Reader.GetStringValue(reader, "Ope_3");
                        oIndicadorEntidad.Ope_4 = Reader.GetStringValue(reader, "Ope_4");
                        oIndicadorEntidad.Ope_5 = Reader.GetStringValue(reader, "Ope_5");
                        oIndicadorEntidad.Ope_6 = Reader.GetStringValue(reader, "Ope_6");
                        oIndicadorEntidad.Ope_7 = Reader.GetStringValue(reader, "Ope_7");
                        oIndicadorEntidad.Ope_8 = Reader.GetStringValue(reader, "Ope_8");
                        oIndicadorEntidad.Ope_9 = Reader.GetStringValue(reader, "Ope_9");
                        oIndicadorEntidad.Ope_10 = Reader.GetStringValue(reader, "Ope_10");
                        oIndicadorEntidad.Ope_11 = Reader.GetStringValue(reader, "Ope_11");
                        oIndicadorEntidad.Ope_12 = Reader.GetStringValue(reader, "Ope_12");
                        oIndicadorEntidad.Ope_13 = Reader.GetStringValue(reader, "Ope_13");
                        oIndicadorEntidad.Ope_14 = Reader.GetStringValue(reader, "Ope_14");
                        oIndicadorEntidad.Ope_15 = Reader.GetStringValue(reader, "Ope_15");
                        oIndicadorEntidad.Ope_16 = Reader.GetStringValue(reader, "Ope_16");
                        oIndicadorEntidad.Ope_17 = Reader.GetStringValue(reader, "Ope_17");
                        oIndicadorEntidad.Ope_18 = Reader.GetStringValue(reader, "Ope_18");
                    }
                }
                return oIndicadorEntidad;
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
        public bool validarModificacionDatos(IndicadorEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Indicadores_ValidarModificacion", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_indicador", SqlDbType.Int)).Value = entidad.Id_Indicador;
                cmd.Parameters.Add(new SqlParameter("@Nom_Indicador", SqlDbType.VarChar, 250)).Value = (entidad.Nom_Indicador != null ? entidad.Nom_Indicador : "");
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
        public bool validarGrabacionDatos(IndicadorEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Usuario_ValidarGrabacion", cn);
                cmd.Parameters.Add(new SqlParameter("@Nom_Indicador", SqlDbType.VarChar, 250)).Value = (entidad.Nom_Indicador != null ? entidad.Nom_Indicador : "");
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
        public bool grabarDatos(IndicadorEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Indicadores_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@Var_Indicador", SqlDbType.VarChar, 10)).Value = entidad.Var_Indicador;
                cmd.Parameters.Add(new SqlParameter("@Nom_Indicador", SqlDbType.VarChar, 100)).Value = entidad.Nom_Indicador;
                cmd.Parameters.Add(new SqlParameter("@Ope_1", SqlDbType.VarChar, 10)).Value = (entidad.Ope_1 != null ? entidad.Ope_1 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_2", SqlDbType.VarChar, 10)).Value = (entidad.Ope_2 != null ? entidad.Ope_2 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_3", SqlDbType.VarChar, 10)).Value = (entidad.Ope_3 != null ? entidad.Ope_3 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_4", SqlDbType.VarChar, 10)).Value = (entidad.Ope_4 != null ? entidad.Ope_4 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_5", SqlDbType.VarChar, 10)).Value = (entidad.Ope_5 != null ? entidad.Ope_5 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_6", SqlDbType.VarChar, 10)).Value = (entidad.Ope_6 != null ? entidad.Ope_6 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_7", SqlDbType.VarChar, 10)).Value = (entidad.Ope_7 != null ? entidad.Ope_7 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_8", SqlDbType.VarChar, 10)).Value = (entidad.Ope_8 != null ? entidad.Ope_8 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_9", SqlDbType.VarChar, 10)).Value = (entidad.Ope_9 != null ? entidad.Ope_9 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_10", SqlDbType.VarChar, 10)).Value = (entidad.Ope_10 != null ? entidad.Ope_10 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_11", SqlDbType.VarChar, 10)).Value = (entidad.Ope_11 != null ? entidad.Ope_11 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_12", SqlDbType.VarChar, 10)).Value = (entidad.Ope_12 != null ? entidad.Ope_12 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_13", SqlDbType.VarChar, 10)).Value = (entidad.Ope_13 != null ? entidad.Ope_13 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_14", SqlDbType.VarChar, 10)).Value = (entidad.Ope_14 != null ? entidad.Ope_14 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_15", SqlDbType.VarChar, 10)).Value = (entidad.Ope_15 != null ? entidad.Ope_15 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_16", SqlDbType.VarChar, 10)).Value = (entidad.Ope_16 != null ? entidad.Ope_16 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_17", SqlDbType.VarChar, 10)).Value = (entidad.Ope_17 != null ? entidad.Ope_17 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_18", SqlDbType.VarChar, 10)).Value = (entidad.Ope_18 != null ? entidad.Ope_18 : "");
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

        public bool modificarDatos(IndicadorEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Indicadores_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_indicador", SqlDbType.Int)).Value = entidad.Id_Indicador;
                cmd.Parameters.Add(new SqlParameter("@Var_Indicador", SqlDbType.VarChar, 10)).Value = entidad.Var_Indicador;
                cmd.Parameters.Add(new SqlParameter("@Nom_Indicador", SqlDbType.VarChar, 100)).Value = entidad.Nom_Indicador;
                cmd.Parameters.Add(new SqlParameter("@Ope_1", SqlDbType.VarChar, 10)).Value = (entidad.Ope_1 != null ? entidad.Ope_1 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_2", SqlDbType.VarChar, 10)).Value = (entidad.Ope_2 != null ? entidad.Ope_2 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_3", SqlDbType.VarChar, 10)).Value = (entidad.Ope_3 != null ? entidad.Ope_3 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_4", SqlDbType.VarChar, 10)).Value = (entidad.Ope_4 != null ? entidad.Ope_4 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_5", SqlDbType.VarChar, 10)).Value = (entidad.Ope_5 != null ? entidad.Ope_5 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_6", SqlDbType.VarChar, 10)).Value = (entidad.Ope_6 != null ? entidad.Ope_6 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_7", SqlDbType.VarChar, 10)).Value = (entidad.Ope_7 != null ? entidad.Ope_7 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_8", SqlDbType.VarChar, 10)).Value = (entidad.Ope_8 != null ? entidad.Ope_8 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_9", SqlDbType.VarChar, 10)).Value = (entidad.Ope_9 != null ? entidad.Ope_9 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_10", SqlDbType.VarChar, 10)).Value = (entidad.Ope_10 != null ? entidad.Ope_10 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_11", SqlDbType.VarChar, 10)).Value = (entidad.Ope_11 != null ? entidad.Ope_11 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_12", SqlDbType.VarChar, 10)).Value = (entidad.Ope_12 != null ? entidad.Ope_12 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_13", SqlDbType.VarChar, 10)).Value = (entidad.Ope_13 != null ? entidad.Ope_13 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_14", SqlDbType.VarChar, 10)).Value = (entidad.Ope_14 != null ? entidad.Ope_14 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_15", SqlDbType.VarChar, 10)).Value = (entidad.Ope_15 != null ? entidad.Ope_15 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_16", SqlDbType.VarChar, 10)).Value = (entidad.Ope_16 != null ? entidad.Ope_16 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_17", SqlDbType.VarChar, 10)).Value = (entidad.Ope_17 != null ? entidad.Ope_17 : "");
                cmd.Parameters.Add(new SqlParameter("@Ope_18", SqlDbType.VarChar, 10)).Value = (entidad.Ope_18 != null ? entidad.Ope_18 : "");
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
