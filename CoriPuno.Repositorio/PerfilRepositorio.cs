﻿using CoriPuno.Entidad;
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
        //public UsuarioEntidad validarUsuario(UsuarioEntidad entidad)
        //{
        //    SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
        //    try
        //    {
        //        Conexion.abrirConexion(cn);
        //        SqlCommand cmd = new SqlCommand("usp_Usuario_Logueo", cn);
        //        cmd.Parameters.Add(new SqlParameter("@Nom_Usuario", SqlDbType.VarChar, 250)).Value = entidad.Nom_Usuario;
        //        cmd.Parameters.Add(new SqlParameter("@Pass_Usuario", SqlDbType.VarChar, 250)).Value = entidad.Pass_Usuario;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        UsuarioEntidad oUsuarioEntidad = null;
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                oUsuarioEntidad = new UsuarioEntidad();
        //                oUsuarioEntidad.Id_Usuario = Reader.GetSmallIntValue(reader, "Id_Usuario");
        //                oUsuarioEntidad.Nom_Usuario = Reader.GetStringValue(reader, "Nom_Usuario");
        //                oUsuarioEntidad.Pass_Usuario = Reader.GetStringValue(reader, "Pass_Usuario");
        //                oUsuarioEntidad.Perfil_Usuario = Reader.GetStringValue(reader, "Perfil_Usuario");
        //                oUsuarioEntidad.Perfil = new PerfilEntidad
        //                {
        //                    Id_Perfil = Reader.GetStringValue(reader, "Id_Perfil")
        //                };
        //                oUsuarioEntidad.ListaPerfilNavegacion = oPerfilNavegacionRepositorio.ListarPerfilesNavegacion(oUsuarioEntidad.Perfil.Id_Perfil);
        //            }
        //        }
        //        return oUsuarioEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        Conexion.cerrarConexion(cn);
        //    }
        //}
        //public List<UsuarioEntidad> obtenerDatosXFiltro(UsuarioEntidad entidad)
        //{
        //    SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
        //    try
        //    {
        //        Conexion.abrirConexion(cn);
        //        SqlCommand cmd = new SqlCommand("usp_Usuario_Filtrar", cn);
        //        cmd.Parameters.Add(new SqlParameter("@Id_Perfil", SqlDbType.VarChar, 5)).Value = (entidad.Perfil.Id_Perfil != null ? entidad.Perfil.Id_Perfil : "");
        //        cmd.Parameters.Add(new SqlParameter("@Nom_Usuario", SqlDbType.VarChar, 250)).Value = (entidad.Nom_Usuario != null ? entidad.Nom_Usuario : "");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        List<UsuarioEntidad> ListaUsuario = new List<UsuarioEntidad>();
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                UsuarioEntidad oUsuarioEntidad = new UsuarioEntidad();
        //                oUsuarioEntidad.Id_Usuario = Reader.GetSmallIntValue(reader, "Id_Usuario");
        //                oUsuarioEntidad.Nom_Usuario = Reader.GetStringValue(reader, "Nom_Usuario");
        //                oUsuarioEntidad.Pass_Usuario = Reader.GetStringValue(reader, "Pass_Usuario");
        //                oUsuarioEntidad.Perfil_Usuario = Reader.GetStringValue(reader, "Perfil_Usuario");
        //                oUsuarioEntidad.Perfil = new PerfilEntidad
        //                {
        //                    Id_Perfil = Reader.GetStringValue(reader, "Id_Perfil"),
        //                    Nom_Perfil = Reader.GetStringValue(reader, "Nom_Perfil"),
        //                };
        //                ListaUsuario.Add(oUsuarioEntidad);
        //            }
        //        }
        //        return ListaUsuario;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        Conexion.cerrarConexion(cn);
        //    }
        //}
        //public UsuarioEntidad obtenerDatosXCodigo(string codigo)
        //{
        //    SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
        //    try
        //    {
        //        Conexion.abrirConexion(cn);
        //        SqlCommand cmd = new SqlCommand("usp_Usuario_BuscarxId", cn);
        //        cmd.Parameters.Add(new SqlParameter("@Id_Usuario", SqlDbType.SmallInt)).Value = Int16.Parse(codigo);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        UsuarioEntidad oUsuarioEntidad = null;
        //        using (var reader = cmd.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                oUsuarioEntidad = new UsuarioEntidad();
        //                oUsuarioEntidad.Id_Usuario = Reader.GetSmallIntValue(reader, "Id_Usuario");
        //                oUsuarioEntidad.Nom_Usuario = Reader.GetStringValue(reader, "Nom_Usuario");
        //                oUsuarioEntidad.Pass_Usuario = Reader.GetStringValue(reader, "Pass_Usuario");
        //                oUsuarioEntidad.Perfil_Usuario = Reader.GetStringValue(reader, "Perfil_Usuario");
        //                oUsuarioEntidad.Perfil = new PerfilEntidad
        //                {
        //                    Id_Perfil = Reader.GetStringValue(reader, "Id_Perfil"),
        //                };
        //            }
        //        }
        //        return oUsuarioEntidad;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    finally
        //    {
        //        Conexion.cerrarConexion(cn);
        //    }
        //}
        //public bool validarModificacionDatos(UsuarioEntidad entidad)
        //{
        //    SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
        //    try
        //    {
        //        bool estado = false;
        //        Conexion.abrirConexion(cn);
        //        SqlCommand cmd = new SqlCommand("usp_Usuario_ValidarModificacion", cn);
        //        cmd.Parameters.Add(new SqlParameter("@Id_Usuario", SqlDbType.SmallInt)).Value = entidad.Id_Usuario;
        //        cmd.Parameters.Add(new SqlParameter("@Nom_Usuario", SqlDbType.VarChar, 250)).Value = (entidad.Nom_Usuario != null ? entidad.Nom_Usuario : "");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        using (var reader = cmd.ExecuteReader())
        //            while (reader.Read()) estado = true;

        //        return estado;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        Conexion.cerrarConexion(cn);
        //    }
        //}
        //public bool validarGrabacionDatos(UsuarioEntidad entidad)
        //{
        //    SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
        //    try
        //    {
        //        bool estado = false;
        //        Conexion.abrirConexion(cn);
        //        SqlCommand cmd = new SqlCommand("usp_Usuario_ValidarGrabacion", cn);
        //        cmd.Parameters.Add(new SqlParameter("@Nom_Usuario", SqlDbType.VarChar, 250)).Value = (entidad.Nom_Usuario != null ? entidad.Nom_Usuario : "");
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        using (var reader = cmd.ExecuteReader())
        //            while (reader.Read()) estado = true;

        //        return estado;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        Conexion.cerrarConexion(cn);
        //    }
        //}
        #endregion
    }
}
