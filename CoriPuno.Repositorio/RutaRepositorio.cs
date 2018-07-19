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
    public  class RutaRepositorio
    {
        #region "Metodos No Transaccionales"

        public List<RutaEntidad> obtenerDatosXFiltro(RutaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_MRutas_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@id_origen", SqlDbType.VarChar, 10)).Value = (entidad.IdOrigen != null ? entidad.IdOrigen : "");
                cmd.Parameters.Add(new SqlParameter("@id_destino", SqlDbType.VarChar, 10)).Value = (entidad.IdDestino != null ? entidad.IdDestino : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<RutaEntidad> ListaRuta = new List<RutaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        RutaEntidad oRutaEntidad = new RutaEntidad();
                        oRutaEntidad.IdRuta = Reader.GetIntValue(reader, "id_ruta");
                        oRutaEntidad.IdOrigen = Reader.GetStringValue(reader, "id_origen");
                        oRutaEntidad.Origen = Reader.GetStringValue(reader, "Origen");
                        oRutaEntidad.IdDestino = Reader.GetStringValue(reader, "id_Destino");
                        oRutaEntidad.Destino = Reader.GetStringValue(reader, "Destino");
                        oRutaEntidad.Distancia = Reader.GetDecimalValue(reader, "nDistancia");
                        oRutaEntidad.Factor = Reader.GetIntValue(reader, "nfactor");
                        ListaRuta.Add(oRutaEntidad);
                    }
                }
                return ListaRuta;
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
        public RutaEntidad obtenerDatosXCodigo(int codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_MRutas_FiltrarxCodigo", cn);
                cmd.Parameters.Add(new SqlParameter("@id_ruta", SqlDbType.Int)).Value = codigo;
                cmd.CommandType = CommandType.StoredProcedure;
                RutaEntidad oRutaEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oRutaEntidad = new RutaEntidad();
                        oRutaEntidad.IdRuta = Reader.GetIntValue(reader, "id_ruta");
                        oRutaEntidad.IdOrigen = Reader.GetStringValue(reader, "id_origen");
                        oRutaEntidad.Origen = Reader.GetStringValue(reader, "Origen");
                        oRutaEntidad.IdDestino = Reader.GetStringValue(reader, "id_Destino");
                        oRutaEntidad.Destino = Reader.GetStringValue(reader, "Destino");
                        oRutaEntidad.Distancia = Reader.GetDecimalValue(reader, "nDistancia");
                        oRutaEntidad.Factor = Reader.GetIntValue(reader, "nfactor");
                    }
                }
                return oRutaEntidad;
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


        public bool modificarDatos(RutaEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_MRutas_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@id_ruta", SqlDbType.Int)).Value = entidad.IdRuta;
                cmd.Parameters.Add(new SqlParameter("@nDistancia", SqlDbType.Decimal)).Value = entidad.Distancia;
                cmd.Parameters.Add(new SqlParameter("@nfactor", SqlDbType.Decimal)).Value = entidad.Factor;
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
