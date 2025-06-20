using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosEntrada
{
    public class HistorialReproduccionME
    {
        public HistorialReproduccionME()
        {
        }

        public int? IdUsuario { get; set; }
        public int? IdCancion { get; set; }
        public DateTime? FechaReproduccion { get; set; }
    }
}
