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
    public class PerfilNavegacionRepositorio
    {
        PerfilNavegacionOpcionRepositorio oPerfilNavegacionOpcionRepositorio = new PerfilNavegacionOpcionRepositorio();
        public List<PerfilNavegacionEntidad> ListarPerfilesNavegacion(string Id_Perfil)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Perfil_NavegacionByPerfil", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Perfil", SqlDbType.VarChar, 5)).Value = Id_Perfil;
                cmd.CommandType = CommandType.StoredProcedure;
                List<PerfilNavegacionEntidad> ListaPerfilesNavegacion = new List<PerfilNavegacionEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PerfilNavegacionEntidad oPerfilNavegacionEntidad=new PerfilNavegacionEntidad();     
                        oPerfilNavegacionEntidad.Id_Navegacion = Reader.GetSmallIntValue(reader, "Id_Navegacion");
                        oPerfilNavegacionEntidad.Paquete = new PaqueteEntidad
                        {
                            Id_Paquete = Reader.GetTinyIntValue(reader, "Id_Paquete"),
                            Nom_Paquete = Reader.GetStringValue(reader, "Nom_Paquete")
                        };
                        oPerfilNavegacionEntidad.ListaPerfilNavegacionOpcion = oPerfilNavegacionOpcionRepositorio.ListarPerfilesNavegacionOpcion(oPerfilNavegacionEntidad.Id_Navegacion);
                        ListaPerfilesNavegacion.Add(oPerfilNavegacionEntidad);
                    }
                }
                return ListaPerfilesNavegacion;
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
