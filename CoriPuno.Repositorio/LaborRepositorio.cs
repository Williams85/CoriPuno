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
    public class LaborRepositorio
    {
        #region "Metodos No Transaccionales"

        public List<LaborEntidad> obtenerDatosXFiltro(LaborEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_MLabor_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR", SqlDbType.VarChar, 10)).Value = (entidad.Codigo != null ? entidad.Codigo : "");
                cmd.Parameters.Add(new SqlParameter("@Descripcion_labor", SqlDbType.VarChar, 50)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
                cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.Char, 2)).Value = (entidad.Tipo != null ? entidad.Tipo : "");
                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.Char, 1)).Value = (entidad.Estado != null ? entidad.Estado : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<LaborEntidad> ListaLabor = new List<LaborEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        LaborEntidad oLaborEntidad = new LaborEntidad();
                        oLaborEntidad.Codigo = Reader.GetStringValue(reader, "ID_LABOR");
                        oLaborEntidad.Descripcion = Reader.GetStringValue(reader, "Descripcion_labor");
                        oLaborEntidad.Tipo = Reader.GetStringValue(reader, "tipo");
                        oLaborEntidad.Ley = Reader.GetDecimalValue(reader, "ley");
                        oLaborEntidad.Capacidad = Reader.GetDecimalValue(reader, "nCapMaxima");
                        oLaborEntidad.PorRoca = Reader.GetDecimalValue(reader, "PorRoca");
                        oLaborEntidad.AReaManiObra = Reader.GetDecimalValue(reader, "AreaManiobra");
                        oLaborEntidad.Estado = Reader.GetStringValue(reader, "estado").Trim();
                        ListaLabor.Add(oLaborEntidad);
                    }
                }
                return ListaLabor;
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
        public LaborEntidad obtenerDatosXCodigo(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_MLabor_FiltrarxCodigo", cn);
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR", SqlDbType.VarChar,10)).Value = codigo;
                cmd.CommandType = CommandType.StoredProcedure;
                LaborEntidad oLaborEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oLaborEntidad = new LaborEntidad();
                        oLaborEntidad.Codigo = Reader.GetStringValue(reader, "ID_LABOR").Trim();
                        oLaborEntidad.Descripcion = Reader.GetStringValue(reader, "Descripcion_labor");
                        oLaborEntidad.Tipo = Reader.GetStringValue(reader, "tipo");
                        oLaborEntidad.Ley = Reader.GetDecimalValue(reader, "ley");
                        oLaborEntidad.Capacidad = Reader.GetDecimalValue(reader, "nCapMaxima");
                        oLaborEntidad.PorRoca = Reader.GetDecimalValue(reader, "PorRoca");
                        oLaborEntidad.AReaManiObra = Reader.GetDecimalValue(reader, "AreaManiobra");
                        oLaborEntidad.FechaApertura = Reader.GetDateTimeValue(reader, "fecape").ToString("dd/MM/yyyy");
                        oLaborEntidad.FechaLey = Reader.GetDateTimeValue(reader, "FechaLey").ToString("dd/MM/yyyy");
                        oLaborEntidad.Id_Mina = Reader.GetTinyIntValue(reader, "Id_Mina");
                        oLaborEntidad.Id_Area = Reader.GetTinyIntValue(reader, "Id_Area");
                        oLaborEntidad.Id_Zona = Reader.GetTinyIntValue(reader, "Id_Zona");
                        oLaborEntidad.Id_Poligono = Reader.GetTinyIntValue(reader, "Id_Poligono");
                    }
                }
                return oLaborEntidad;
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
        public bool validarModificacionDatos(LaborEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_MLabor_ValidarModificacion", cn);
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR_A", SqlDbType.VarChar,10)).Value = entidad.Codigo_A;
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR", SqlDbType.VarChar, 10)).Value = entidad.Codigo;
                cmd.Parameters.Add(new SqlParameter("@Descripcion_labor", SqlDbType.VarChar, 50)).Value = entidad.Descripcion;
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
        public bool validarGrabacionDatos(LaborEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_MLabor_ValidarGrabacion", cn);
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR", SqlDbType.VarChar, 10)).Value = entidad.Codigo;
                cmd.Parameters.Add(new SqlParameter("@Descripcion_labor", SqlDbType.VarChar, 50)).Value = entidad.Descripcion;
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
        public bool grabarDatos(LaborEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_MLabor_Registrar", cn);
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR", SqlDbType.VarChar,10)).Value = entidad.Codigo;
                cmd.Parameters.Add(new SqlParameter("@Descripcion_labor", SqlDbType.VarChar, 50)).Value = entidad.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.Char, 2)).Value = entidad.Tipo;
                cmd.Parameters.Add(new SqlParameter("@ley", SqlDbType.Decimal)).Value = entidad.Ley;
                cmd.Parameters.Add(new SqlParameter("@nCapMaxima", SqlDbType.Decimal)).Value = entidad.Capacidad;
                cmd.Parameters.Add(new SqlParameter("@PorRoca", SqlDbType.Decimal)).Value = entidad.PorRoca;
                cmd.Parameters.Add(new SqlParameter("@AreaManiobra", SqlDbType.Decimal)).Value = entidad.AReaManiObra;
                cmd.Parameters.Add(new SqlParameter("@fecape", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FechaApertura);
                cmd.Parameters.Add(new SqlParameter("@FechaLey", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FechaLey);
                cmd.Parameters.Add(new SqlParameter("@Id_Mina", SqlDbType.TinyInt)).Value = entidad.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Id_Area", SqlDbType.TinyInt)).Value = entidad.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_Zona", SqlDbType.TinyInt)).Value = entidad.Id_Zona;
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

        public bool modificarDatos(LaborEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_MLabor_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR", SqlDbType.VarChar, 10)).Value = entidad.Codigo;
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR_A", SqlDbType.VarChar, 10)).Value = entidad.Codigo_A;
                cmd.Parameters.Add(new SqlParameter("@Descripcion_labor", SqlDbType.VarChar, 50)).Value = entidad.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@tipo", SqlDbType.Char, 2)).Value = entidad.Tipo;
                cmd.Parameters.Add(new SqlParameter("@ley", SqlDbType.Decimal)).Value = entidad.Ley;
                cmd.Parameters.Add(new SqlParameter("@ley_A", SqlDbType.Decimal)).Value = entidad.Ley_A;
                cmd.Parameters.Add(new SqlParameter("@nCapMaxima", SqlDbType.Decimal)).Value = entidad.Capacidad;
                cmd.Parameters.Add(new SqlParameter("@PorRoca", SqlDbType.Decimal)).Value = entidad.PorRoca;
                cmd.Parameters.Add(new SqlParameter("@AreaManiobra", SqlDbType.Decimal)).Value = entidad.AReaManiObra;
                cmd.Parameters.Add(new SqlParameter("@fecape", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FechaApertura);
                cmd.Parameters.Add(new SqlParameter("@FechaLey", SqlDbType.DateTime)).Value = DateTime.Parse(entidad.FechaLey);
                cmd.Parameters.Add(new SqlParameter("@Id_Mina", SqlDbType.TinyInt)).Value = entidad.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Id_Area", SqlDbType.TinyInt)).Value = entidad.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_Zona", SqlDbType.TinyInt)).Value = entidad.Id_Zona;

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
        public bool cerrarLabor(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("cerrarlabor", cn);
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR", SqlDbType.VarChar, 10)).Value = codigo;

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
        public bool abrirLabor(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("abrirlabor", cn);
                cmd.Parameters.Add(new SqlParameter("@ID_LABOR", SqlDbType.VarChar, 10)).Value = codigo;

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
