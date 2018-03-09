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
    public class PerfilNavegacionOpcionRepositorio
    {
        public List<PerfilNavegacionOpcionEntidad> ListarPerfilesNavegacionOpcion(int Id_Navegacion)
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_Perfil_Navegacion_OpcionByIdNavegacion", cn);
                cmd.Parameters.Add(new SqlParameter("@Id_Navegacion", SqlDbType.Int)).Value = Id_Navegacion;
                cmd.CommandType = CommandType.StoredProcedure;
                List<PerfilNavegacionOpcionEntidad> ListaPerfilesNavegacionOpcion = new List<PerfilNavegacionOpcionEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PerfilNavegacionOpcionEntidad oPerfilNavegacionOpcionEntidad = new PerfilNavegacionOpcionEntidad();
                        oPerfilNavegacionOpcionEntidad.Id_Opcion = Reader.GetIntValue(reader, "Id_Opcion");
                        oPerfilNavegacionOpcionEntidad.Pagina = new PaginaEntidad
                        {
                            Nom_Pagina = Reader.GetStringValue(reader, "Nom_Pagina"),
                            Url_Pagina = Reader.GetStringValue(reader, "Url_Pagina")
                        };
                        ListaPerfilesNavegacionOpcion.Add(oPerfilNavegacionOpcionEntidad);
                    }
                }
                return ListaPerfilesNavegacionOpcion;
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
