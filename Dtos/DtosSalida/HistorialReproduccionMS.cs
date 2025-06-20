using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class HistorialReproduccionMS
    {
        public HistorialReproduccionMS()
        {
        }

        public HistorialReproduccionMS(int idHistorial, int? idUsuario, int? idCancion, DateTime? fechaReproduccion)
        {
            IdHistorial = idHistorial;
            IdUsuario = idUsuario;
            IdCancion = idCancion;
            FechaReproduccion = fechaReproduccion;
        }

        public int IdHistorial { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdCancion { get; set; }
        public DateTime? FechaReproduccion { get; set; }
        public string? NombreCancion { get; set; }
    }
}
