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
    public class DistribucionEquiposRepositorio
    {
        public bool distribuirEquipos(DateTime fecha, string turno)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("DistribuyeEquipo", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.CommandType = CommandType.StoredProcedure;
                //if (cmd.ExecuteNonQuery() > 0)
                //    estado = true;
                cmd.ExecuteNonQuery();
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

        public List<DistribucionEquiposEntidad> listarProgramacionEquipos(DateTime fecha, string turno)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("listarprogramacionequipos", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.CommandType = CommandType.StoredProcedure;
                List<DistribucionEquiposEntidad> listaprogramacionesequipos = new List<DistribucionEquiposEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DistribucionEquiposEntidad oDistribucionEquiposEntidad = new DistribucionEquiposEntidad();
                        oDistribucionEquiposEntidad.Fecha = Reader.GetDateTimeValue(reader, "fini");
                        oDistribucionEquiposEntidad.Turno = Reader.GetStringValue(reader, "turno");
                        oDistribucionEquiposEntidad.UbicacionInicial = Reader.GetStringValue(reader, "lab_ubic_inicial");
                        oDistribucionEquiposEntidad.LaborTrabajo = Reader.GetStringValue(reader, "Lab_trabajo");
                        oDistribucionEquiposEntidad.Equipo = Reader.GetStringValue(reader, "cDescripcion");
                        oDistribucionEquiposEntidad.IdEquipo = Reader.GetIntValue(reader, "id_equipo");
                        oDistribucionEquiposEntidad.Marca = Reader.GetStringValue(reader, "Marca");
                        oDistribucionEquiposEntidad.AñoFabricacion = Reader.GetIntValue(reader, "añoFabrica");
                        oDistribucionEquiposEntidad.HoraInicio = Reader.GetStringValue(reader, "Hora_inicio");
                        oDistribucionEquiposEntidad.TotalHorasDeplazadas = Reader.GetDecimalValue(reader, "nTotalHrDesplazo");
                        oDistribucionEquiposEntidad.TotalHorasEfectivas = Reader.GetDecimalValue(reader, "ntotalHrEfectiva");
                        oDistribucionEquiposEntidad.LaborOrigen = Reader.GetStringValue(reader, "Labor_or");
                        oDistribucionEquiposEntidad.LaborDestino = Reader.GetStringValue(reader, "Labor_de");
                        listaprogramacionesequipos.Add(oDistribucionEquiposEntidad);
                    }
                }

                return listaprogramacionesequipos;
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

        public bool asignarEquipo(DateTime fecha, string turno, string laboror, string laborde, int idequipo)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("CargaEquipo", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
                cmd.Parameters.Add(new SqlParameter("@Labor_or", SqlDbType.VarChar, 10)).Value = laboror;
                cmd.Parameters.Add(new SqlParameter("@Labor_de", SqlDbType.VarChar, 10)).Value = laborde;
                cmd.Parameters.Add(new SqlParameter("@equipo", SqlDbType.Int)).Value = idequipo;
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

        public bool cerrarProgramacionEquipos(DateTime fecha, string turno)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("cerrarprogramacionequipos", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = fecha;
                cmd.Parameters.Add(new SqlParameter("@turno", SqlDbType.VarChar, 10)).Value = turno;
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
