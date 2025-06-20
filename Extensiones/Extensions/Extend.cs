using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Extensiones.Extensions
{
    public static class Extend
    {
        public static string GenerarNombreUsuario(this string nombresCompletos)
        {
            var nombres = nombresCompletos.Split(' ');

            if (nombres.Length > 2)
            {
                throw new ArgumentException("El nombre completo debe contener solo un nombre y un apellido.");
            }

            return nombres[0].Substring(0, 1).ToUpper() + nombres[1].ToUpper();
        }
    }
}
