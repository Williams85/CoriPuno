using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CoriPuno.Utilitario
{
    public class Functions
    {
        public static string obtenerMes(string mes)
        {
            string NombreMes = string.Empty;
            switch (mes.Trim())
            {
                case "1":
                    NombreMes = "Enero";
                    break;
                case "2":
                    NombreMes = "Febrero";
                    break;
                case "3":
                    NombreMes = "Marzo";
                    break;
                case "4":
                    NombreMes = "Abril";
                    break;
                case "5":
                    NombreMes = "Mayo";
                    break;
                case "6":
                    NombreMes = "Junio";
                    break;
                case "7":
                    NombreMes = "Julio";
                    break;
                case "8":
                    NombreMes = "Agosto";
                    break;
                case "9":
                    NombreMes = "Setiembre";
                    break;
                case "10":
                    NombreMes = "Octubre";
                    break;
                case "11":
                    NombreMes = "Noviembre";
                    break;
                case "12":
                    NombreMes = "Diciembre";
                    break;

            }
            return NombreMes;
        }
        public static string obtenerLabor(string labor)
        {
            string NombreLabor = string.Empty;
            switch (labor.Trim())
            {
                case "OR":
                    NombreLabor = "Origen";
                    break;
                case "DE":
                    NombreLabor = "Destino";
                    break;

            }
            return NombreLabor;
        }

        public static string obtenerTurno(string turno)
        {
            string NombreTurno = string.Empty;
            switch (turno)
            {
                case "0001":
                    NombreTurno = "Mañana";
                    break;
                case "0002":
                    NombreTurno = "Tarde";
                    break;
                case "0003":
                    NombreTurno = "Noche";
                    break;
            }
            return NombreTurno;
        }

        public static string obtenerEstado(string estado)
        {
            string NombreEstado = string.Empty;
            switch (estado)
            {
                case "A":
                    NombreEstado = "Abierto";
                    break;
                case "C":
                    NombreEstado = "Cerrado";
                    break;
                case "O":
                    NombreEstado = "Observado";
                    break;
                default:
                    NombreEstado = "Generado";
                    break;
            }
            return NombreEstado;
        }

        public static string obtenerMensajeGeneracionProgramacion(int codigo)
        {
            string Mensaje = string.Empty;
            switch (codigo)
            {
                case 1:
                    Mensaje = "Nuevo programa generado";
                    break;
                case 2:
                    Mensaje = "Programa regenerado";
                    break;
                case 3:
                    Mensaje = "Programa ya ha sido generado y cerrado";
                    break;
                case 4:
                    Mensaje = "No existe labores destino activa";
                    break;
                case 5:
                    Mensaje = "No existe labores origen activas";
                    break;
                default:
                    Mensaje = "Ocurrio un error al generar el programa";
                    break;
            }
            return Mensaje;
        }

        public static string Encriptar(string valor)
        {
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi");
            // La clave debe ser de 8 caracteres
            byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5");
            // No se puede alterar la cantidad de caracteres pero si la clave
            byte[] buffer = Encoding.UTF8.GetBytes(valor);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        public static string Desencriptar(string valor)
        {
            byte[] IV = ASCIIEncoding.ASCII.GetBytes("qualityi");
            // La clave debe ser de 8 caracteres
            byte[] EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5");
            // No se puede alterar la cantidad de caracteres pero si la clave
            byte[] buffer = Convert.FromBase64String(valor);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;
            return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

    }
}
