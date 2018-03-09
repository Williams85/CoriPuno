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
    public class PoligonoDominio
    {
        private PoligonoRepositorio oPoligonoRepositorio = new PoligonoRepositorio();



        #region "Metodos No Transaccionales"
        public List<PoligonoEntidad> Listar(ZonaEntidad entidad)
        {
            return oPoligonoRepositorio.Listar(entidad);
        }
        public List<PoligonoEntidad> obtenerDatosXFiltro(PoligonoEntidad entidad)
        {

            return oPoligonoRepositorio.obtenerDatosXFiltro(entidad);
        }
        public PoligonoEntidad obtenerDatosXCodigo(string codigo)
        {
            return oPoligonoRepositorio.obtenerDatosXCodigo(codigo);
        }

        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(PoligonoEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oPoligonoRepositorio.validarGrabacionDatos(entidad)) mensaje = Message.ExistePoligono;
            else
            {
                if (oPoligonoRepositorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.GraboPoligono;
                }
                else
                    mensaje = Message.NoGraboPoligono;
            }
            return estado;
        }

        public bool modificarDatos(PoligonoEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oPoligonoRepositorio.validarModificacionDatos(entidad)) mensaje = Message.ExistePoligono;
            else
            {
                if (oPoligonoRepositorio.modificarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.ModificoPoligono;
                }
                else
                    mensaje = Message.NoModificoPoligono;
            }
            return estado;
        }



        #endregion
    }
}
