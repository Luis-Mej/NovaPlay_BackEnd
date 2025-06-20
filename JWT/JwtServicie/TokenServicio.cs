using Dtos.DtosSalida;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT.JwtServicie
{
    public class TokenServicio : ITokenServicie
    {
        private readonly IConfiguration _configuration;

        public TokenServicio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CrearToken(UsuarioMS usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre ?? string.Empty),
                new Claim("Avatar", usuario.Avatar ?? string.Empty),
                new Claim("IdUsuario", usuario.IdUsuario.ToString()),
                new Claim("Email", usuario.Email ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:Expiration"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
