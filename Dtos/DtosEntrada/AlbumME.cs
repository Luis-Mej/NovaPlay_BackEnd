using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosEntrada
{
    public class AlbumME
    {
        public AlbumME()
        {
        }

        public string? Nombre { get; set; }
        public int? IdArtista { get; set; }
        public int? AnioLanzamiento { get; set; }
        public string? Portada { get; set; }
    }
}
