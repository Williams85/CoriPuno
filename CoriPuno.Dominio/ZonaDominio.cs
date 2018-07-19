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
    public class ZonaDominio
    {
        private ZonaRepositorio oZonaRepositorio = new ZonaRepositorio();



        #region "Metodos No Transaccionales"
        public List<ZonaEntidad> Listar(AreaEntidad entidad)
        {
            return oZonaRepositorio.Listar(entidad);
        }
        public List<ZonaEntidad> obtenerDatosXFiltro(ZonaEntidad entidad)
        {

            return oZonaRepositorio.obtenerDatosXFiltro(entidad);
        }
        public ZonaEntidad obtenerDatosXCodigo(string codigo)
        {
            return oZonaRepositorio.obtenerDatosXCodigo(codigo);
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(ZonaEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oZonaRepositorio.validarGrabacionDatos(entidad)) mensaje = Message.ExisteZona;
            else
            {
                if (oZonaRepositorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.GraboZona;
                }
                else
                    mensaje = Message.NoGraboZona;
            }
            return estado;
        }

        public bool modificarDatos(ZonaEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oZonaRepositorio.validarModificacionDatos(entidad)) mensaje = Message.ExisteZona;
            else
            {
                if (oZonaRepositorio.modificarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.ModificoZona;
                }
                else
                    mensaje = Message.NoModificoZona;
            }
            return estado;
        }



        #endregion
    }
}
