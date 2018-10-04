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
    public class BlendingRepositorio
    {
        public bool EjecucionBlending(string FechaProceso, decimal Capacidad, ref string Mensaje)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            SqlTransaction trans = null;
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                trans = cn.BeginTransaction();
                SqlCommand cmd01 = new SqlCommand("sp_creaBlending ", cn);
                cmd01.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = FechaProceso;
                cmd01.Parameters.Add(new SqlParameter("@capcarga", SqlDbType.Decimal, 12)).Value = Capacidad;
                cmd01.Parameters.Add(new SqlParameter("@eeblend", SqlDbType.Int)).Direction = ParameterDirection.Output;
                cmd01.CommandType = CommandType.StoredProcedure;
                cmd01.Transaction = trans;
                cmd01.ExecuteNonQuery();
                var Indicador = int.Parse(cmd01.Parameters["@eeblend"].Value.ToString());

                if (Indicador == 0)
                {
                    SqlCommand cmd02 = new SqlCommand("GeneraBlending ", cn);
                    cmd02.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = FechaProceso;
                    cmd02.CommandType = CommandType.StoredProcedure;
                    cmd02.Transaction = trans;
                    if (cmd02.ExecuteNonQuery() > 0)
                    {
                        estado = true;
                        trans.Commit();
                    }
                    else
                    {
                        trans.Rollback();
                    }

                }
                return estado;
            }
            catch (Exception ex)
            {
                if (trans != null) trans.Rollback();                
                return false;
                throw;
            }
        }

        public int ConfirmarBlending(string FechaProceso)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                int indicador = 1;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("sp_confirmaBlendig", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = FechaProceso;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0) indicador = 0;
                return indicador;
            }
            catch (Exception ex)
            {
                return 1;
                throw;
            }
        }

        public int EliminarBlending(string FechaProceso)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                int indicador = 1;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("SP_ELIMINABLENDING", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = FechaProceso;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.ExecuteNonQuery() > 0) indicador = 0;
                return indicador;
            }
            catch (Exception ex)
            {
                return 1;
                throw;
            }
        }

        public DProducciontoPlanta_CabEntidad ResultadoEjecBlending(string FechaProceso)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                bool estado = false;
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_ResultadoEjecBlending ", cn);
                cmd.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = FechaProceso;
                cmd.CommandType = CommandType.StoredProcedure;
                DProducciontoPlanta_CabEntidad entidad = new DProducciontoPlanta_CabEntidad();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    entidad.Id_ToPlant = Reader.GetIntValue(reader, "id_toplant");
                    entidad.NCntLabores = Reader.GetIntValue(reader, "ncntlabores");
                    entidad.NLeyOptima = Reader.GetDecimalValue(reader, "nleyoptima");
                    entidad.NTot_TM = Reader.GetDecimalValue(reader, "ntot_tm");
                    entidad.Und_Minina = Reader.GetDecimalValue(reader, "und_minina");

                }
                reader.NextResult();
                entidad.DetalleProduccionPlantaDTMP = new List<DProducciontoPlanta_dtmpEntidad>();
                while (reader.Read())
                {
                    DProducciontoPlanta_dtmpEntidad oDProducciontoPlanta_dtmpEntidad = new DProducciontoPlanta_dtmpEntidad();
                    oDProducciontoPlanta_dtmpEntidad.Id_ToPlant = Reader.GetIntValue(reader, "id_toplant");
                    oDProducciontoPlanta_dtmpEntidad.Id_Labor = Reader.GetStringValue(reader, "id_labor");
                    oDProducciontoPlanta_dtmpEntidad.Ley = Reader.GetDecimalValue(reader, "ley");
                    oDProducciontoPlanta_dtmpEntidad.TM_Disponible = Reader.GetDecimalValue(reader, "tm_disponible");
                    oDProducciontoPlanta_dtmpEntidad.TM_Optimizado = Reader.GetDecimalValue(reader, "tm_optimizado");
                    entidad.DetalleProduccionPlantaDTMP.Add(oDProducciontoPlanta_dtmpEntidad);
                }

                return entidad;
            }
            catch (Exception ex)
            {
                return null;
                throw;
            }
        }

    }
}
