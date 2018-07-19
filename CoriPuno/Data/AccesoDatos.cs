using CoriPuno.Data.Base_Datos;
using CoriPuno.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CoriPuno.Data
{
    public class AccesoDatos
    {
        public ParametrosEntidad obtenerParametros()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Parametros_Listar", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                ParametrosEntidad oParametrosEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oParametrosEntidad = new ParametrosEntidad();
                        oParametrosEntidad.CapProdMaxima = Reader.GetDecimalValue(reader, "CapProdMaxima");
                        oParametrosEntidad.CostoTNxKm = Reader.GetDecimalValue(reader, "CostoTNxKm");
                    }
                }
                return oParametrosEntidad;
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
    }
}