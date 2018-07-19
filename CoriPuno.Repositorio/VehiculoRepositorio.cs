using CoriPuno.Entidad;
using CoriPuno.Repositorio.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CoriPuno.Repositorio
{
    public class VehiculoRepositorio
    {



        #region "Metodos No Transaccionales"
        public VehiculoEntidad obtenerDatosXFiltro(string placa)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("VehiculoFiltrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Placa", SqlDbType.VarChar, 10)).Value = placa;
                cmd.CommandType = CommandType.StoredProcedure;
                VehiculoEntidad entidad = null;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    entidad = new VehiculoEntidad();
                    entidad.IdVehiculo = Reader.GetIntValue(reader, "id_vehiculos");
                    entidad.Placa = Reader.GetStringValue(reader, "Placa");
                    entidad.Contrata = Reader.GetStringValue(reader, "Contrata");
                    entidad.Tara = Reader.GetDecimalValue(reader, "Tara");
                    entidad.Capacidad = Reader.GetDecimalValue(reader, "Capacidad");

                }

                return entidad;
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
        public List<VehiculoEntidad> listarPesoVehiculo(DateTime fecha, string turno, string placa, string labor_or)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("listardetallepesovehiculo", cn);
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@labor_or", SqlDbType.VarChar, 10)).Value = labor_or;
                cmd.Parameters.Add(new SqlParameter("@Turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.CommandType = CommandType.StoredProcedure;
                List<VehiculoEntidad> listavehiculopeso = new List<VehiculoEntidad>();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    VehiculoEntidad oVehiculoEntidad = new VehiculoEntidad();
                    oVehiculoEntidad.Placa = Reader.GetStringValue(reader, "Placa");
                    oVehiculoEntidad.Contrata = Reader.GetStringValue(reader, "Contrata");
                    oVehiculoEntidad.Tara = Reader.GetDecimalValue(reader, "Tara");
                    oVehiculoEntidad.Hora_Pesaje = Reader.GetStringValue(reader, "Hora_Pesaje");
                    oVehiculoEntidad.Peso2 = Reader.GetDecimalValue(reader, "peso_ini");
                    oVehiculoEntidad.PesoNeto = Reader.GetDecimalValue(reader, "PesoNeto");
                    listavehiculopeso.Add(oVehiculoEntidad);
                }

                return listavehiculopeso;
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
        public List<VehiculoEntidad> Filtrar(VehiculoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mVehiculos_Filtrar", cn);
                cmd.Parameters.Add(new SqlParameter("@Placa", SqlDbType.VarChar, 10)).Value = (entidad.Placa != null ? entidad.Placa : "");
                cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.VarChar, 10)).Value = (entidad.Marca != null ? entidad.Marca : "");
                cmd.CommandType = CommandType.StoredProcedure;
                List<VehiculoEntidad> ListaVehiculos = new List<VehiculoEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VehiculoEntidad oVehiculoEntidad = new VehiculoEntidad();
                        oVehiculoEntidad.IdVehiculo = Reader.GetIntValue(reader, "id_vehiculos");
                        oVehiculoEntidad.Placa = Reader.GetStringValue(reader, "Placa");
                        oVehiculoEntidad.Tara = Reader.GetDecimalValue(reader, "Tara");
                        oVehiculoEntidad.Capacidad = Reader.GetDecimalValue(reader, "Capacidad");
                        oVehiculoEntidad.Contrata = Reader.GetIntValue(reader, "contrata").ToString();
                        oVehiculoEntidad.Razon_Social = Reader.GetStringValue(reader, "Razon_social").ToString();
                        oVehiculoEntidad.Marca = Reader.GetStringValue(reader, "Marca");
                        ListaVehiculos.Add(oVehiculoEntidad);
                    }
                }

                return ListaVehiculos;
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
        public VehiculoEntidad obtenerDatosXCodigo(string codigo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mVehiculos_BuscarxId", cn);
                cmd.Parameters.Add(new SqlParameter("@id_vehiculos", SqlDbType.Int)).Value = Int32.Parse(codigo);
                cmd.CommandType = CommandType.StoredProcedure;
                VehiculoEntidad oVehiculoEntidad = null;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        oVehiculoEntidad = new VehiculoEntidad();
                        oVehiculoEntidad.IdVehiculo = Reader.GetIntValue(reader, "id_vehiculos");
                        oVehiculoEntidad.Placa = Reader.GetStringValue(reader, "Placa");
                        oVehiculoEntidad.Tara = Reader.GetDecimalValue(reader, "Tara");
                        oVehiculoEntidad.Capacidad = Reader.GetDecimalValue(reader, "Capacidad");
                        oVehiculoEntidad.Contrata = Reader.GetIntValue(reader, "contrata").ToString();
                        oVehiculoEntidad.Marca = Reader.GetStringValue(reader, "Marca");
                    }
                }
                return oVehiculoEntidad;
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
        public bool validarModificacionDatos(VehiculoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mVehiculos_ValidarModificacion", cn);
                cmd.Parameters.Add(new SqlParameter("@id_vehiculos", SqlDbType.Int)).Value = entidad.IdVehiculo;
                cmd.Parameters.Add(new SqlParameter("@Placa", SqlDbType.VarChar, 10)).Value = entidad.Placa;
                cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.VarChar, 10)).Value = entidad.Marca;

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
        public bool validarGrabacionDatos(VehiculoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mVehiculos_ValidarGrabacion", cn);
                cmd.Parameters.Add(new SqlParameter("@Placa", SqlDbType.VarChar, 10)).Value = entidad.Placa;
                cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.VarChar, 10)).Value = entidad.Marca;
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
        public bool grabarDatos(VehiculoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_mVehiculos_Grabar", cn);
                cmd.Parameters.Add(new SqlParameter("@Placa", SqlDbType.VarChar, 10)).Value = entidad.Placa;
                cmd.Parameters.Add(new SqlParameter("@Tara", SqlDbType.Real)).Value = entidad.Tara;
                cmd.Parameters.Add(new SqlParameter("@Capacidad", SqlDbType.Real)).Value = entidad.Capacidad;
                cmd.Parameters.Add(new SqlParameter("@contrata", SqlDbType.Int)).Value = Int32.Parse(entidad.Contrata);
                cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.VarChar, 10)).Value = entidad.Marca;
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

        public bool modificarDatos(VehiculoEntidad entidad)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("usp_mVehiculos_Modificar", cn);
                cmd.Parameters.Add(new SqlParameter("@id_vehiculos", SqlDbType.Int)).Value = entidad.IdVehiculo;
                cmd.Parameters.Add(new SqlParameter("@Placa", SqlDbType.VarChar, 10)).Value = entidad.Placa;
                cmd.Parameters.Add(new SqlParameter("@Tara", SqlDbType.Real)).Value = entidad.Tara;
                cmd.Parameters.Add(new SqlParameter("@Capacidad", SqlDbType.Real)).Value = entidad.Capacidad;
                cmd.Parameters.Add(new SqlParameter("@contrata", SqlDbType.Int)).Value = Int32.Parse(entidad.Contrata);
                cmd.Parameters.Add(new SqlParameter("@Marca", SqlDbType.VarChar, 10)).Value = entidad.Marca;
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
