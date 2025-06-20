using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class PlaylistCancionesMS
    {
        public PlaylistCancionesMS()
        {
        }

        public PlaylistCancionesMS(int idPlaylistCancion, int? idPlaylist, int? idCancion)
        {
            IdPlaylistCancion = idPlaylistCancion;
            IdPlaylist = idPlaylist;
            IdCancion = idCancion;
        }

        public int IdPlaylistCancion { get; set; }
        public int? IdPlaylist { get; set; }
        public int? IdCancion { get; set; }
        public string? NombreCancion { get; set; }
    }
}
