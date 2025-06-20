using Dtos.DtosEntrada;
using Dtos.DtosSalida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.JwtServicie
{
    public interface ITokenServicie
    {
        string CrearToken(UsuarioMS usuario);
    }
}
