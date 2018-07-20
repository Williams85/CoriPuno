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
    public class ComponenteRepositorio
    {
        #region "Metodos No Transaccionales"
        public List<ComponenteEntidad> obtenerDatosXFiltro(ComponenteEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Componentes_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 100)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
                cmd.Parameters.Add(new SqlParameter("@cSigla", SqlDbType.VarChar, 20)).Value = (entidad.Sigla != null ? entidad.Sigla : "");
                cmd.Parameters.Add(new SqlParameter("@cUnidadMedida", SqlDbType.VarChar, 20)).Value = (entidad.UnidadMedida != null ? entidad.UnidadMedida : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<ComponenteEntidad> ListaComponente = new List<ComponenteEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ComponenteEntidad oComponenteEntidad = new ComponenteEntidad();
                        oComponenteEntidad.Id_Componente = Reader.GetIntValue(reader, "Id_Componente");
                        oComponenteEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        oComponenteEntidad.Sigla = Reader.GetStringValue(reader, "cSigla");
                        oComponenteEntidad.UnidadMedida = Reader.GetStringValue(reader, "cUnidadMedida");
                        oComponenteEntidad.Fuente = Reader.GetStringValue(reader, "cFuente");
                        oComponenteEntidad.Procedimiento = Reader.GetStringValue(reader, "cProcedimiento");
                        oComponenteEntidad.Estado = Reader.GetStringValue(reader, "IEstado");
                        ListaComponente.Add(oComponenteEntidad);
                    }
                }
                return ListaComponente;
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
        public ComponenteEntidad obtenerDatosXCodigo(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Componentes_BuscarxId", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Componente", SqlDbType.Int)).Value = Int32.Parse(codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                ComponenteEntidad oComponenteEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oComponenteEntidad = new ComponenteEntidad();
                        oComponenteEntidad.Id_Componente = Reader.GetIntValue(reader, "Id_Componente");
                        oComponenteEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        oComponenteEntidad.Sigla = Reader.GetStringValue(reader, "cSigla");
                        oComponenteEntidad.UnidadMedida = Reader.GetStringValue(reader, "cUnidadMedida");
                        oComponenteEntidad.Fuente = Reader.GetStringValue(reader, "cFuente");
                        oComponenteEntidad.Procedimiento = Reader.GetStringValue(reader, "cProcedimiento");
                        oComponenteEntidad.Estado = Reader.GetStringValue(reader, "IEstado");
                    }
                }
                return oComponenteEntidad;
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
        public bool validarModificacionDatos(ComponenteEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Componentes_ValidarModificacion", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Componente", SqlDbType.Int)).Value = entidad.Id_Componente;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 100)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
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
        public bool validarGrabacionDatos(ComponenteEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Componentes_ValidarGrabacion", cn);
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 100)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
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
        public bool grabarDatos(ComponenteEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Componentes_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 100)).Value = entidad.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@cSigla", SqlDbType.VarChar, 20)).Value = entidad.Sigla;
                cmd.Parameters.Add(new SqlParameter("@cUnidadMedida", SqlDbType.VarChar, 20)).Value = entidad.UnidadMedida;
                cmd.Parameters.Add(new SqlParameter("@cFuente", SqlDbType.VarChar, 200)).Value = entidad.Fuente;
                cmd.Parameters.Add(new SqlParameter("@cProcedimiento", SqlDbType.VarChar, 200)).Value = (entidad.Procedimiento != null ? entidad.Procedimiento : "");
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

        public bool modificarDatos(ComponenteEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Componentes_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Componente", SqlDbType.Int)).Value = entidad.Id_Componente;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 100)).Value = entidad.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@cSigla", SqlDbType.VarChar, 20)).Value = entidad.Sigla;
                cmd.Parameters.Add(new SqlParameter("@cUnidadMedida", SqlDbType.VarChar, 20)).Value = entidad.UnidadMedida;
                cmd.Parameters.Add(new SqlParameter("@cFuente", SqlDbType.VarChar, 200)).Value = entidad.Fuente;
                cmd.Parameters.Add(new SqlParameter("@cProcedimiento", SqlDbType.VarChar, 200)).Value = (entidad.Procedimiento != null ? entidad.Procedimiento : "");
                cmd.Parameters.Add(new SqlParameter("@IEstado", SqlDbType.Char, 1)).Value = entidad.Estado;
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
