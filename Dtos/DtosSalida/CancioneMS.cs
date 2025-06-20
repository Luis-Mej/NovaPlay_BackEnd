using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class CancioneMS
    {
        public CancioneMS()
        {
        }

        public CancioneMS(int idCancion, string? nombre, int? idArtista, int? idAlbum, TimeOnly? duracion, string? archivo, string? genero)
        {
            IdCancion = idCancion;
            Nombre = nombre;
            IdArtista = idArtista;
            IdAlbum = idAlbum;
            Duracion = duracion;
            Archivo = archivo;
            Genero = genero;
        }

        public int IdCancion { get; set; }
        public string? Nombre { get; set; }
        public int? IdArtista { get; set; }
        public int? IdAlbum { get; set; }
        public TimeOnly? Duracion { get; set; }
        public string? Archivo { get; set; }
        public string? Genero { get; set; }
        public string? NombreArtista { get; set; }
        public string? NombreAlbum { get; set; }
    }
}
