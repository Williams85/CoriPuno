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


        #region "Metodos No Transaccionales"

        public List<ZonaEntidad> Listar(AreaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Zona_Listar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Id_Area", SqlDbType.TinyInt)).Value = entidad.Id_Area;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ZonaEntidad> ListaZona = new List<ZonaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ZonaEntidad oZonaEntidad = new ZonaEntidad();
                        oZonaEntidad.Id_Zona = Reader.GetTinyIntValue(reader, "Id_Zona");
                        oZonaEntidad.Area = new AreaEntidad
                        {
                            Id_Area = Reader.GetIntValue(reader, "Id_Area")
                        };
                        oZonaEntidad.Mina = new MinaEntidad
                        {
                            Id_Mina = Reader.GetIntValue(reader, "Id_Mina"),
                        };

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
        public List<ZonaEntidad> obtenerDatosXFiltro(ZonaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Zona_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<ZonaEntidad> ListaZonas = new List<ZonaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ZonaEntidad oZonaEntidad = new ZonaEntidad();
                        oZonaEntidad.Id_Zona = Reader.GetIntValue(reader, "Id_zona");
                        oZonaEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        oZonaEntidad.Fec_Inicio = Reader.GetDateTimeValue(reader, "Fec_Inicio").ToString("dd/MM/yyyy");
                        oZonaEntidad.Estado = Reader.GetStringValue(reader, "Estado");
                        oZonaEntidad.Area = new AreaEntidad
                        {
                            Descripcion = Reader.GetStringValue(reader, "Area"),
                        };
                        oZonaEntidad.Mina = new MinaEntidad
                        {
                            Descripcion = Reader.GetStringValue(reader, "Mina"),
                        };

                        ListaZonas.Add(oZonaEntidad);
                    }
                }
                return ListaZonas;
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
        public ZonaEntidad obtenerDatosXCodigo(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Zona_BuscarxId", cn);
                cmd.Parameters.Add(new SqlParameter("@id_zona", SqlDbType.Int)).Value = Int32.Parse(codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                ZonaEntidad oZonaEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oZonaEntidad = new ZonaEntidad();
                        oZonaEntidad.Id_Zona = Reader.GetIntValue(reader, "Id_zona");
                        oZonaEntidad.Descripcion = Reader.GetStringValue(reader, "cDescripcion");
                        oZonaEntidad.Fec_Inicio = Reader.GetDateTimeValue(reader, "Fec_Inicio").ToString("dd/MM/yyyy");
                        oZonaEntidad.Estado = Reader.GetStringValue(reader, "Estado");
                        oZonaEntidad.Area = new AreaEntidad
                        {
                            Id_Area = Reader.GetIntValue(reader, "id_area"),
                        };
                        oZonaEntidad.Mina = new MinaEntidad
                        {
                            Id_Mina = Reader.GetIntValue(reader, "id_mina"),
                        };
                    }
                }
                return oZonaEntidad;
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
        public bool validarModificacionDatos(ZonaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Zona_ValidarModificacion", cn);
                cmd.Parameters.Add(new SqlParameter("@id_zona", SqlDbType.Int)).Value = entidad.Id_Zona;
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = entidad.Descripcion;
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
        public bool validarGrabacionDatos(ZonaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Zona_ValidarGrabacion", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = entidad.Descripcion;
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
        public bool grabarDatos(ZonaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Zona_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = entidad.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Fec_inicio", SqlDbType.DateTime)).Value = entidad.Fec_Inicio;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Char, 1)).Value = entidad.Estado;
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

        public bool modificarDatos(ZonaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Zona_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_zona", SqlDbType.SmallInt)).Value = entidad.Id_Zona;
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@cDescripcion", SqlDbType.VarChar, 20)).Value = entidad.Descripcion;
                cmd.Parameters.Add(new SqlParameter("@Fec_inicio", SqlDbType.DateTime)).Value = entidad.Fec_Inicio;
                cmd.Parameters.Add(new SqlParameter("@Estado", SqlDbType.Char, 1)).Value = entidad.Estado;
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
