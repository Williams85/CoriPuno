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
                //List<ProgramacionDiariaEntidad> listaprogramaciones = new List<ProgramacionDiariaEntidad>();
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
    }
}
