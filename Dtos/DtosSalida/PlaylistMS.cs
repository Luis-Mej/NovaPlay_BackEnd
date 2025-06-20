using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class PlaylistMS
    {
        public PlaylistMS()
        {
        }

        public PlaylistMS(int idPlaylist, string? nombre, int? idUsuario, string? portada)
        {
            IdPlaylist = idPlaylist;
            Nombre = nombre;
            IdUsuario = idUsuario;
            Portada = portada;
        }

        public int IdPlaylist { get; set; }
        public string? Nombre { get; set; }
        public int? IdUsuario { get; set; }
        public string? Portada { get; set; }

        public List<PlaylistCancionesMS>? PlaylistCanciones { get; set; }
    }
}
