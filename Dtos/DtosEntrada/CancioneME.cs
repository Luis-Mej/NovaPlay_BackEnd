using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosEntrada
{
    public class CancioneME
    {
        public CancioneME()
        {
        }

        public string? Nombre { get; set; }
        public int? IdArtista { get; set; }
        public int? IdAlbum { get; set; }
        public TimeOnly? Duracion { get; set; }
        public string? Archivo { get; set; }
        public string? Genero { get; set; }
    }
}
