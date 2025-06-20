using Dtos.DtosEntrada;
using Dtos.DtosSalida;
using Dtos;
using Encryptador.Encriptar;
using Entities.Context;
using JWT.JwtServicie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Negocio.Servicios
{
    public class LoginServicios
    {
        private readonly NovaplayDbContext _context;
        private readonly ITokenServicie _tokenServicio;

        public LoginServicios(NovaplayDbContext context, ITokenServicie tokenServicio)
        {
            _context = context;
            _tokenServicio = tokenServicio;
        }

        public async Task<ResponseBase<UsuarioTokenMS>> Login(UsuarioLoginME dto)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Avatar == dto.Avatar && u.Estado == "A");

            if (usuario == null || usuario.Contrasenia != Encriptador.Encriptar(dto.Contrasenia))
                return new ResponseBase<UsuarioTokenMS>(400, "Credenciales incorrectas");

            
            var usuarioParaToken = new UsuarioMS
            {
                IdUsuario = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Email = usuario.Email
            };

            string token = _tokenServicio.CrearToken(usuarioParaToken);

            var usuarioToken = new UsuarioTokenMS(
                usuario.IdUsuario,
                usuario.Nombre,
                usuario.Email,
                token
            );

            return new ResponseBase<UsuarioTokenMS>(200, "Login exitoso", usuarioToken);
        }
    }
}