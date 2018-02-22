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
    public class ProgramacionDiariaCabRepositorio
    {
        public bool cerrarProgramacion(DateTime fecha, string turno)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("cerrarprogramacion", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery()>0)
                    estado = true;

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

        public List<ProgramacionDiariaCabEntidad> listarProgramacionPendientes()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("listaprogramacioncerradas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<ProgramacionDiariaCabEntidad> listaprogramaciones = new List<ProgramacionDiariaCabEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProgramacionDiariaCabEntidad oProgramacionDiariaCabEntidad = new ProgramacionDiariaCabEntidad();
                        oProgramacionDiariaCabEntidad.Fecha = Reader.GetDateTimeValue(reader, "fecha");
                        oProgramacionDiariaCabEntidad.Turno = Reader.GetStringValue(reader, "turno");
                        oProgramacionDiariaCabEntidad.LeyMinima = Reader.GetDecimalValue(reader, "nleymin");
                        oProgramacionDiariaCabEntidad.LeyMaxima = Reader.GetDecimalValue(reader, "nleymax");
                        oProgramacionDiariaCabEntidad.CostoAproximado = Reader.GetDecimalValue(reader, "nCostoAprox");
                        oProgramacionDiariaCabEntidad.LeyPromedio = Reader.GetDecimalValue(reader, "nLeyPromedio");
                        oProgramacionDiariaCabEntidad.Estado = Reader.GetStringValue(reader, "Estado");
                        listaprogramaciones.Add(oProgramacionDiariaCabEntidad);
                    }
                }

                return listaprogramaciones;
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

        public List<ProgramacionDiariaCabEntidad> ProgramacionesGeneradas()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("ProgramacionesGeneradas", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                List<ProgramacionDiariaCabEntidad> listaprogramaciones = new List<ProgramacionDiariaCabEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ProgramacionDiariaCabEntidad oProgramacionDiariaCabEntidad = new ProgramacionDiariaCabEntidad();
                        oProgramacionDiariaCabEntidad.Fecha = Reader.GetDateTimeValue(reader, "fecha");
                        oProgramacionDiariaCabEntidad.Turno = Reader.GetStringValue(reader, "turno");
                        oProgramacionDiariaCabEntidad.LeyMinima = Reader.GetDecimalValue(reader, "nleymin");
                        oProgramacionDiariaCabEntidad.LeyMaxima = Reader.GetDecimalValue(reader, "nleymax");
                        oProgramacionDiariaCabEntidad.CostoAproximado = Reader.GetDecimalValue(reader, "nCostoAprox");
                        oProgramacionDiariaCabEntidad.LeyPromedio = Reader.GetDecimalValue(reader, "nLeyPromedio");
                        oProgramacionDiariaCabEntidad.Estado = Reader.GetStringValue(reader, "Estado");
                        listaprogramaciones.Add(oProgramacionDiariaCabEntidad);
                    }
                }

                return listaprogramaciones;
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


        public bool ProgramacionModificarEstado(DateTime fecha, string turno, string flag)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("programacionmodificarestado", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.Char, 1)).Value = flag;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0)
                    estado = true;

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
    }
}
