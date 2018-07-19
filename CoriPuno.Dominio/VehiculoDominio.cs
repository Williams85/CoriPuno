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
    public class VehiculoDominio
    {
        private VehiculoRepositorio oVehiculoRepositorio = new VehiculoRepositorio();

        #region "Metodos No Transaccionales"
        public VehiculoEntidad obtenerDatosXFiltro(string placa)
        {
            return oVehiculoRepositorio.obtenerDatosXFiltro(placa);
        }
        public List<VehiculoEntidad> listarPesoVehiculo(DateTime fecha, string turno, string placa, string labor_or)
        {
            return oVehiculoRepositorio.listarPesoVehiculo(fecha, turno, placa, labor_or);
        }
        public List<VehiculoEntidad> Filtrar(VehiculoEntidad entidad)
        {
            return oVehiculoRepositorio.Filtrar(entidad);
        }
        public VehiculoEntidad obtenerDatosXCodigo(string codigo)
        {
            return oVehiculoRepositorio.obtenerDatosXCodigo(codigo);
        }
        #endregion

        #region "Metodos Transaccionales"
        public bool grabarDatos(VehiculoEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oVehiculoRepositorio.validarGrabacionDatos(entidad)) mensaje = Message.ExisteVehiculo;
            else
            {
                if (oVehiculoRepositorio.grabarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.GraboVehiculo;
                }
                else
                    mensaje = Message.NoGraboVehiculo;
            }
            return estado;
        }
        public bool modificarDatos(VehiculoEntidad entidad, ref string mensaje)
        {
            bool estado = false;
            if (oVehiculoRepositorio.validarModificacionDatos(entidad)) mensaje = Message.ExisteVehiculo;
            else
            {
                if (oVehiculoRepositorio.modificarDatos(entidad))
                {
                    estado = true;
                    mensaje = Message.ModificoVehiculo;
                }
                else
                    mensaje = Message.NoModificoVehiculo;
            }
            return estado;
        }
        #endregion

    }
}
