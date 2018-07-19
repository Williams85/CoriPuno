using CoriPuno.Entidad;
using CoriPuno.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Dominio
{
    public class LaborDominio
    {
        private LaborRepositorio oLaborReposotorio = new LaborRepositorio();

        #region "Metodos No Transaccionales"

        public List<LaborEntidad> obtenerDatosXFiltro(LaborEntidad entidad)
        {
            var Lista = oLaborReposotorio.obtenerDatosXFiltro(entidad);
            int CantidadOrigen = 0;
            int CantidadDestino = 0;

            var ListaOrigen = oLaborReposotorio.obtenerDatosXFiltro(new LaborEntidad
            {
                Codigo = "",
                Descripcion = "",
                Tipo = "OR",
                Estado = "A",
            });
            var ListaDestino = oLaborReposotorio.obtenerDatosXFiltro(new LaborEntidad
            {
                Codigo = "",
                Descripcion = "",
                Tipo = "DE",
                Estado = "A",
            });
            if (ListaOrigen != null && ListaOrigen.Count > 0)
                CantidadOrigen = ListaOrigen.Count;

            if (ListaDestino != null && ListaDestino.Count > 0)
                CantidadDestino = ListaDestino.Count;


            for (int i = 0; i <= Lista.Count - 1; i++)
            {
                Lista[i].CantOrigen = CantidadOrigen;
                Lista[i].CantDestino = CantidadDestino;
            }
            return Lista;

        }
        public LaborEntidad obtenerDatosXCodigo(string codigo)
        {
            return oLaborReposotorio.obtenerDatosXCodigo(codigo);
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(LaborEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oLaborReposotorio.validarGrabacionDatos(entidad)) mensaje = "La labor ingresada existe...";
            else
            {
                if (oLaborReposotorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = "Labor registrada correctamente...";
                }
                else
                    mensaje = "No se registro la labor ...";
            }
            return estado;
        }

        public bool modificarDatos(LaborEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oLaborReposotorio.validarModificacionDatos(entidad)) mensaje = "La labor ingresada existe...";
            else
            {
                if (oLaborReposotorio.modificarDatos(entidad))
                {
                    estado = true;
                    mensaje = "Labor modificada correctamente...";
                }
                else
                    mensaje = "No se modifico la labor ...";
            }
            return estado;
        }

        public bool cerrarLabor(string codigo)
        {
            return oLaborReposotorio.cerrarLabor(codigo);
        }

        public bool abrirLabor(string codigo)
        {
            return oLaborReposotorio.abrirLabor(codigo);
        }

        #endregion
    }
}
