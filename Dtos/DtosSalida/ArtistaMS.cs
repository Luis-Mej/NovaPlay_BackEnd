using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class ArtistaMS
    {
        public ArtistaMS()
        {
        }

        public ArtistaMS(int idArtista, string? nombre, string? descripcion, string? imagen)
        {
            IdArtista = idArtista;
            Nombre = nombre;
            Descripcion = descripcion;
            Imagen = imagen;
        }

        public int IdArtista { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
        public List<int>? AlbumesIds { get; set; }
    }
}
