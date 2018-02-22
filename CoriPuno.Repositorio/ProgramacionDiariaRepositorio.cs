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
    public class ProgramacionDiariaRepositorio
    {
        public bool calcularProgramacion(DateTime fecha, string turno, decimal leyminima, decimal leymaxima, ref int result)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("cargaprograma", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar,10)).Value = turno;
                cmd.Parameters.Add(new SqlParameter("@leymin", SqlDbType.Decimal,18)).Value = leyminima;
                cmd.Parameters.Add(new SqlParameter("@leymax", SqlDbType.Decimal,18)).Value = leymaxima;
                cmd.Parameters.Add(new SqlParameter("@codmes", SqlDbType.Int)).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                result = (cmd.Parameters["@codmes"].Value != null ? int.Parse(cmd.Parameters["@codmes"].Value.ToString()) : 0);
                return true;
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

        public ProgramacionDiariaCabEntidad listarProgramacion(DateTime fecha, string turno)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("listarprogramaciongeneradas", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.CommandType = CommandType.StoredProcedure;
                ProgramacionDiariaCabEntidad entidad = new ProgramacionDiariaCabEntidad();
                //List<ProgramacionDiariaEntidad> listaprogramaciones = new List<ProgramacionDiariaEntidad>();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    entidad.Estado = Reader.GetStringValue(reader, "Estado");
                    entidad.CostoAproximado = Reader.GetDecimalValue(reader, "nCostoAprox");
                    entidad.LeyPromedio = Reader.GetDecimalValue(reader, "nLeyPromedio");

                }
                reader.NextResult();
                entidad.DetalleProgramacion = new List<ProgramacionDiariaEntidad>();
                while (reader.Read())
                {
                    ProgramacionDiariaEntidad oProgramacionDiariaEntidad = new ProgramacionDiariaEntidad();
                    oProgramacionDiariaEntidad.Año = Reader.GetIntValue(reader, "año");
                    oProgramacionDiariaEntidad.Mes = Reader.GetStringValue(reader, "mes");
                    oProgramacionDiariaEntidad.FechaInicio = Reader.GetDateTimeValue(reader, "fini");
                    oProgramacionDiariaEntidad.FechaEjecucion = Reader.GetDateTimeValue(reader, "feceje");
                    oProgramacionDiariaEntidad.Turno = Reader.GetStringValue(reader, "turno");
                    oProgramacionDiariaEntidad.LaborOrigen = Reader.GetStringValue(reader, "Labor_or");
                    oProgramacionDiariaEntidad.LaborDestino = Reader.GetStringValue(reader, "labor_de");
                    oProgramacionDiariaEntidad.Ley = Reader.GetDecimalValue(reader, "Ley");
                    oProgramacionDiariaEntidad.CapacidadMaxima = Reader.GetDecimalValue(reader, "CapMaxima");
                    oProgramacionDiariaEntidad.Distancia = Reader.GetDecimalValue(reader, "distancia");
                    oProgramacionDiariaEntidad.ToneladasProcesar = Reader.GetDecimalValue(reader, "nTonMet");
                    entidad.DetalleProgramacion.Add(oProgramacionDiariaEntidad);
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

        public List<ProgramacionDiariaEntidad> listarDetalleProgramacion(DateTime fecha, string turno)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("listarprogramaciondetalle", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ProgramacionDiariaEntidad> listaprogramacionesdetalle = new List<ProgramacionDiariaEntidad>();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProgramacionDiariaEntidad oProgramacionDiariaEntidad = new ProgramacionDiariaEntidad();
                    oProgramacionDiariaEntidad.LaborOrigen = Reader.GetStringValue(reader, "LaborOr");
                    oProgramacionDiariaEntidad.LaborDestino = Reader.GetStringValue(reader, "LaborDe");
                    oProgramacionDiariaEntidad.Ley = Reader.GetDecimalValue(reader, "Ley");
                    oProgramacionDiariaEntidad.Distancia = Reader.GetDecimalValue(reader, "distancia");
                    oProgramacionDiariaEntidad.ToneladasProcesar = Reader.GetDecimalValue(reader, "nTonMet");
                    listaprogramacionesdetalle.Add(oProgramacionDiariaEntidad);
                }

                return listaprogramacionesdetalle;
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

        public List<ProgramacionDiariaEntidad> listarProgramacionCapturaPeso(DateTime fecha, string turno)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("listarprogramacioncapturapeso", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.CommandType = CommandType.StoredProcedure;
                List<ProgramacionDiariaEntidad> listaprogramacionesdetalle = new List<ProgramacionDiariaEntidad>();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProgramacionDiariaEntidad oProgramacionDiariaEntidad = new ProgramacionDiariaEntidad();
                    oProgramacionDiariaEntidad.Id_Prog = Reader.GetIntValue(reader, "id_Prog");
                    oProgramacionDiariaEntidad.FechaEjecucion = Reader.GetDateTimeValue(reader, "feceje");
                    oProgramacionDiariaEntidad.Turno = Reader.GetStringValue(reader, "turno");
                    oProgramacionDiariaEntidad.IdOrigen = Reader.GetStringValue(reader, "Labor_or");
                    oProgramacionDiariaEntidad.IdDestino = Reader.GetStringValue(reader, "labor_de");
                    oProgramacionDiariaEntidad.LaborOrigen = Reader.GetStringValue(reader, "Origen");
                    oProgramacionDiariaEntidad.LaborDestino = Reader.GetStringValue(reader, "Destino");
                    oProgramacionDiariaEntidad.ToneladasProcesar = Reader.GetDecimalValue(reader, "nTonMet");
                    oProgramacionDiariaEntidad.ToneladasEjecucion = Reader.GetDecimalValue(reader, "nTotMet_ejec");
                    listaprogramacionesdetalle.Add(oProgramacionDiariaEntidad);
                }

                return listaprogramacionesdetalle;
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
