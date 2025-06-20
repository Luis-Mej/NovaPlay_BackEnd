using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosSalida
{
    public class RecomendacionesMS
    {
        public RecomendacionesMS()
        {}

        public RecomendacionesMS(int idRecomendacion, int? idUsuario, string? prompt, string? recomendacion, DateTime? fecha)
        {
            IdRecomendacion = idRecomendacion;
            IdUsuario = idUsuario;
            Prompt = prompt;
            Recomendacion = recomendacion;
            Fecha = fecha;
        }

        public RecomendacionesMS(int idRecomendacion, int? idUsuario, string? nombre, string? prompt, string? recomendacion, DateTime? fecha)
        {
            IdRecomendacion = idRecomendacion;
            IdUsuario = idUsuario;
            Nombre = nombre;
            Prompt = prompt;
            Recomendacion = recomendacion;
            Fecha = fecha;
        }

        public int IdRecomendacion { get; set; }
        public int? IdUsuario { get; set; }
        public string? Prompt { get; set; }
        public string? Recomendacion { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Nombre { get; set; }
    }
}
