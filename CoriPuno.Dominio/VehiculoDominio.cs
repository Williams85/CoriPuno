using CoriPuno.Entidad;
using CoriPuno.Repositorio;
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

        public VehiculoEntidad obtenerDatosXFiltro(string placa)
        {
            return oVehiculoRepositorio.obtenerDatosXFiltro(placa);
        }

        public List<VehiculoEntidad> listarPesoVehiculo(DateTime fecha, string turno, string placa, string labor_or)
        {
            return oVehiculoRepositorio.listarPesoVehiculo(fecha, turno, placa, labor_or);
        }
    }
}
