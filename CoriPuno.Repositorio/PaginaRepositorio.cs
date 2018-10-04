using CoriPuno.Entidad;
using CoriPuno.Repositorio.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CoriPuno.Repositorio
{
    public class PaginaRepositorio
    {
        #region "Metodos No Transaccionales"

        public List<PaginaEntidad> ListarActivos()
        {
            SqlConnection cn = new SqlConnection(Conexion.CnCoriPuno);
            try
            {
                Conexion.abrirConexion(cn);
                SqlCommand cmd = new SqlCommand("usp_mPagina_Listar", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                List<PaginaEntidad> ListaPagina = new List<PaginaEntidad>();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        PaginaEntidad oPaginaEntidad = new PaginaEntidad();
                        oPaginaEntidad.Id_Pagina = Reader.GetTinyIntValue(reader, "Id_Pagina");
                        oPaginaEntidad.Nom_Pagina = Reader.GetStringValue(reader, "Nom_Pagina");
                        oPaginaEntidad.Url_Pagina = Reader.GetStringValue(reader, "Url_Pagina");
                        ListaPagina.Add(oPaginaEntidad);
                    }
                }

                return ListaPagina;
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
    }
}
