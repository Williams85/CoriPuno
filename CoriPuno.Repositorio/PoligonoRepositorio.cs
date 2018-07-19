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
    public class PoligonoRepositorio
    {


        #region "Metodos No Transaccionales"

        public List<PoligonoEntidad> Listar(ZonaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Poligono_Listar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Mina", SqlDbType.TinyInt)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Id_Area", SqlDbType.TinyInt)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_Zona", SqlDbType.TinyInt)).Value = entidad.Id_Zona;

                cmd.CommandType = CommandType.StoredProcedure;
                List<PoligonoEntidad> ListaPoligono = new List<PoligonoEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PoligonoEntidad oPoligonoEntidad = new PoligonoEntidad();
                        oPoligonoEntidad.Id_Poligono = Reader.GetTinyIntValue(reader, "Id_Poligono");
                        oPoligonoEntidad.Zona = new ZonaEntidad
                        {
                            Id_Zona=Reader.GetIntValue(reader, "Id_Zona"),
                        };
                        oPoligonoEntidad.Area = new AreaEntidad
                        {
                            Id_Area = Reader.GetIntValue(reader, "Id_Area"),
                        };
                        oPoligonoEntidad.Mina = new MinaEntidad {
                            Id_Mina = Reader.GetIntValue(reader, "Id_Mina"),
                        };
                        oPoligonoEntidad.Descripcion = Reader.GetStringValue(reader, "Descripcion");
                        ListaPoligono.Add(oPoligonoEntidad);
                    }
                }

                return ListaPoligono;
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
        public List<PoligonoEntidad> obtenerDatosXFiltro(PoligonoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Poligono_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Id_zona", SqlDbType.Int)).Value = entidad.Zona.Id_Zona;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 20)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<PoligonoEntidad> ListaPoligonos = new List<PoligonoEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PoligonoEntidad oPoligonoEntidad = new PoligonoEntidad();
                        oPoligonoEntidad.Id_Poligono = Reader.GetIntValue(reader, "Id_Poligono");
                        oPoligonoEntidad.Descripcion = Reader.GetStringValue(reader, "Descripcion");
                        oPoligonoEntidad.Area = new AreaEntidad
                        {
                            Descripcion = Reader.GetStringValue(reader, "Area"),
                        };
                        oPoligonoEntidad.Mina = new MinaEntidad
                        {
                            Descripcion = Reader.GetStringValue(reader, "Mina"),
                        };
                        oPoligonoEntidad.Zona = new ZonaEntidad
                        {
                            Descripcion = Reader.GetStringValue(reader, "Zona"),
                        };

                        ListaPoligonos.Add(oPoligonoEntidad);
                    }
                }
                return ListaPoligonos;
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
        public PoligonoEntidad obtenerDatosXCodigo(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Poligono_BuscarxId", cn);
                cmd.Parameters.Add(new SqlParameter("@id_poligono", SqlDbType.Int)).Value = Int32.Parse(codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                PoligonoEntidad oPoligonoEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oPoligonoEntidad = new PoligonoEntidad();
                        oPoligonoEntidad.Id_Poligono = Reader.GetIntValue(reader, "Id_Poligono");
                        oPoligonoEntidad.Descripcion = Reader.GetStringValue(reader, "Descripcion");
                        oPoligonoEntidad.Area = new AreaEntidad
                        {
                            Id_Area = Reader.GetIntValue(reader, "id_area"),
                        };
                        oPoligonoEntidad.Mina = new MinaEntidad
                        {
                            Id_Mina = Reader.GetIntValue(reader, "id_mina"),
                        };
                        oPoligonoEntidad.Zona = new ZonaEntidad
                        {
                            Id_Zona = Reader.GetIntValue(reader, "Id_Zona"),
                        };
                    }
                }
                return oPoligonoEntidad;
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
        public bool validarModificacionDatos(PoligonoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Poligono_ValidarModificacion", cn);
                cmd.Parameters.Add(new SqlParameter("@id_poligono", SqlDbType.Int)).Value = entidad.Id_Poligono;
                cmd.Parameters.Add(new SqlParameter("@id_zona", SqlDbType.Int)).Value = entidad.Zona.Id_Zona;
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 20)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
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
        public bool validarGrabacionDatos(PoligonoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Poligono_ValidarGrabacion", cn);
                cmd.Parameters.Add(new SqlParameter("@id_zona", SqlDbType.Int)).Value = entidad.Zona.Id_Zona;
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 20)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
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
        public bool grabarDatos(PoligonoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Poligono_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@id_zona", SqlDbType.Int)).Value = entidad.Zona.Id_Zona;
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 20)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
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

        public bool modificarDatos(PoligonoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_Poligono_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@id_poligono", SqlDbType.Int)).Value = entidad.Id_Poligono;
                cmd.Parameters.Add(new SqlParameter("@id_zona", SqlDbType.Int)).Value = entidad.Zona.Id_Zona;
                cmd.Parameters.Add(new SqlParameter("@Id_area", SqlDbType.Int)).Value = entidad.Area.Id_Area;
                cmd.Parameters.Add(new SqlParameter("@Id_mina", SqlDbType.Int)).Value = entidad.Mina.Id_Mina;
                cmd.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 20)).Value = (entidad.Descripcion != null ? entidad.Descripcion : "");
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
