using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class UsuarioTokenMS
    {
        public UsuarioTokenMS(int idUsuario, string nombre, string email, string token)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Email = email;
            Token = token;
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

    }
}
