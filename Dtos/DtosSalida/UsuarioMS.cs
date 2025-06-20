using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class UsuarioMS
    {
        public UsuarioMS()
        {}

        public UsuarioMS(int idUsuario, string? nombre, string? email, string? contrasenia ,string? avatar, DateTime? fechaRegistro)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Email = email;
            Contrasenia = contrasenia;
            Avatar = avatar;
            FechaRegistro = fechaRegistro;
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Email { get; set; }
        public string? Contrasenia { get; set; }
        public string? Avatar { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public List<int>? PlaylistIds { get; set; }
        public List<int>? RecomendacionesIds { get; set; }
        public List<int>? HistorialReproduccionIds { get; set; }
    }
}
