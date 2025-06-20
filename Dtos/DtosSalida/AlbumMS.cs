using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class AlbumMS
    {
        public AlbumMS()
        {
        }

        public AlbumMS(int idAlbum, string? nombre, int? idArtista, int? anioLanzamiento, string? portada)
        {
            IdAlbum = idAlbum;
            Nombre = nombre;
            IdArtista = idArtista;
            AnioLanzamiento = anioLanzamiento;
            Portada = portada;
        }

        public int IdAlbum { get; set; }
        public string? Nombre { get; set; }
        public int? IdArtista { get; set; }
        public int? AnioLanzamiento { get; set; }
        public string? Portada { get; set; }
        public List<PlaylistCancionesMS>? Canciones { get; set; }
        public string? NombreArtista { get; set; }
    }
}
