using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using CoriPuno.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class PerfilDominio
    {
        PerfilRepositorio oPerfilRepositorio = new PerfilRepositorio();
        PerfilNavegacionRepositorio oPerfilNavegacionRepositorio = new PerfilNavegacionRepositorio();
        PerfilNavegacionOpcionRepositorio oPerfilNavegacionOpcionRepositorio = new PerfilNavegacionOpcionRepositorio();

        public List<PerfilEntidad> ListarActivos()
        {
            return oPerfilRepositorio.ListarActivos();
        }
        public List<PerfilEntidad> Filtrar(string Nom_Perfil)
        {
            var ListaPerfiles = oPerfilRepositorio.Filtrar(Nom_Perfil);
            for (int i = 0; i <= ListaPerfiles.Count - 1; i++)
            {
                ListaPerfiles[i].ListaNavegacion = oPerfilNavegacionRepositorio.ListarPerfilesNavegacion(ListaPerfiles[i].Id_Perfil);
                for (int x = 0; x <= ListaPerfiles[i].ListaNavegacion.Count - 1; x++)
                {
                    ListaPerfiles[i].ListaNavegacion[x].ListaPerfilNavegacionOpcion = oPerfilNavegacionOpcionRepositorio.ListarPerfilesNavegacionOpcion(ListaPerfiles[i].ListaNavegacion[x].Id_Navegacion);                 
                }
            }
            return ListaPerfiles;
        }

        #region "Metodos Transaccionales"
        public bool grabarDatos(PerfilEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oPerfilRepositorio.validarGrabacionDatos(entidad)) mensaje = Message.ExistePerfil;
            else
            {
                if (oPerfilRepositorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.GraboPerfil;
                }
                else
                    mensaje = Message.NoGraboPerfil;
            }
            return estado;
        }

        #endregion

    }
}
