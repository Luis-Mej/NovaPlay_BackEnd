using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.DtosEntrada
{
    public class RecomendacioneME
    {
        public RecomendacioneME()
        {
        }

        public int IdUsuario { get; set; }
        public string Prompt { get; set; }
    }
}
