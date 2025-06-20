using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosEntrada
{
    public class UsuarioME
    {
        public UsuarioME()
        {}

        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contrasenia { get; set; }
        public object?[]? IdUsuario { get; set; }
    }
}
