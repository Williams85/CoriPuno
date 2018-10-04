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
    public class PerfilRepositorio
    {

        #region "Metodos No Transaccionales"
        public List<PerfilEntidad> ListarActivos()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Perfil_ListarActivos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<PerfilEntidad> ListaPerfil = new List<PerfilEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PerfilEntidad oPerfilEntidad = new PerfilEntidad();
                        oPerfilEntidad.Id_Perfil = Reader.GetStringValue(reader, "Id_Perfil");
                        oPerfilEntidad.Nom_Perfil = Reader.GetStringValue(reader, "Nom_Perfil");
                        ListaPerfil.Add(oPerfilEntidad);
                    }
                }
                return ListaPerfil;
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
        public List<PerfilEntidad> Filtrar(string Nom_Perfil)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mPerfil_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Nom_Perfil", SqlDbType.VarChar, 100)).Value = (Nom_Perfil != null ? Nom_Perfil : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<PerfilEntidad> ListaPerfil = new List<PerfilEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PerfilEntidad oPerfilEntidad = new PerfilEntidad();
                        oPerfilEntidad.Id_Perfil = Reader.GetStringValue(reader, "Id_Perfil");
                        oPerfilEntidad.Nom_Perfil = Reader.GetStringValue(reader, "Nom_Perfil");
                        oPerfilEntidad.Activo = Reader.GetBooleanValue(reader, "Activo");
                        ListaPerfil.Add(oPerfilEntidad);
                    }
                }
                return ListaPerfil;
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

        public bool validarGrabacionDatos(PerfilEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mPerfil_ValidacionGrabacion", cn);
                cmd.Parameters.Add(new SqlParameter("@Nom_Perfil", SqlDbType.VarChar, 150)).Value = (entidad.Nom_Perfil != null ? entidad.Nom_Perfil : "");
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
        public bool grabarDatos(PerfilEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_mPerfil_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@Nom_Perfil", SqlDbType.VarChar, 150)).Value = (entidad.Nom_Perfil != null ? entidad.Nom_Perfil : "");
                cmd.Parameters.Add(new SqlParameter("@Id_Perfil", SqlDbType.VarChar, 150)).Direction = ParameterDirection.Output;
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
