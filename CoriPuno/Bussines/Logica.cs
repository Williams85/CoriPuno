using CoriPuno.Data;
using CoriPuno.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoriPuno.Bussines
{
    public class Logica
    {
        private AccesoDatos oAccesoDatos = new AccesoDatos();
        public ParametrosEntidad obtenerParametros()
        {
            return oAccesoDatos.obtenerParametros();
        }
    }
}