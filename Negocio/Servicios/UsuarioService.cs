using Dtos;
using Dtos.DtosEntrada;
using Dtos.DtosSalida;
using Encryptador.Encriptar;
using Entities.Context;
using Entities.Models;
using JWT.JwtServicie;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using Extensiones.Extensions;

namespace Negocio.Servicios
{
    public class UsuarioService
    {
        private readonly NovaplayDbContext _context;
        private readonly ITokenServicie _tokenServicio;

        public UsuarioService(NovaplayDbContext context, ITokenServicie tokenServicio)
        {
            _context = context;
            _tokenServicio = tokenServicio;
        }

        private bool EmailEsValido(string email)
        {
            try
            {
                var mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ResponseBase<List<UsuarioMS>>> GetUsuariosAsync()
        {
            var usuarios = await _context.Usuarios
                .Where(u => u.Estado == "A")
                .Select(u => new UsuarioMS(
                    u.IdUsuario,
                    u.Nombre,
                    u.Email,
                    u.Contrasenia,
                    u.Avatar,
                    u.FechaRegistro))
                .ToListAsync();

            return new ResponseBase<List<UsuarioMS>>(200, usuarios);
        }

        public async Task<ResponseBase<string>> CrearUsuarioAsync(UsuarioME dto)
        {
            if (!EmailEsValido(dto.Email))
                return new ResponseBase<string>(400, "El correo electrónico no es válido.");

            var existe = await _context.Usuarios.AnyAsync(u => u.Email == dto.Email);
            if (existe)
                return new ResponseBase<string>(400, "El correo ya está registrado.");

            string nombreUsuario = dto.Nombre.GenerarNombreUsuario();

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Contrasenia = Encriptador.Encriptar(dto.Contrasenia),
                Avatar = nombreUsuario,
                FechaRegistro = DateTime.Now,
                Estado = "A"
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            await EnviarCorreoConfirmacion(dto.Email, nombreUsuario);

            return new ResponseBase<string>(200, "Usuario registrado correctamente. Se ha enviado el usuario a su correo.");
        }

        public async Task<ResponseBase<string>> ActualizarUsuarioAsync(int id, UsuarioME dto)
        {
            var usuario = await _context.Usuarios.FindAsync(dto.IdUsuario);
            if (usuario == null || usuario.Estado != "A")
                return new ResponseBase<string>(404, "Usuario no encontrado");

            usuario.Nombre = dto.Nombre;
            usuario.Email = dto.Email;
            usuario.Contrasenia = Encriptador.Encriptar(dto.Contrasenia);
            usuario.Avatar = dto.Nombre.GenerarNombreUsuario();

            await _context.SaveChangesAsync();

            return new ResponseBase<string>(200, "Usuario actualizado");
        }

        public async Task<ResponseBase<string>> EliminarUsuarioAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null || usuario.Estado != "A")
                return new ResponseBase<string>(404, "Usuario no encontrado");

            usuario.Estado = "I";
            await _context.SaveChangesAsync();

            return new ResponseBase<string>(200, "Usuario eliminado");
        }

        private async Task EnviarCorreoConfirmacion(string email, string nombreUsuario)
        {
            try
            {
                using (var client = new SmtpClient("smtp.tuservidor.com", 587))
                {
                    client.Credentials = new NetworkCredential("tu_email@tudominio.com", "tu_contraseña");
                    client.EnableSsl = true;

                    var message = new MailMessage("tu_email@tudominio.com", email)
                    {
                        Subject = "Confirmación de Registro - NovaPlay",
                        Body = $"¡Bienvenido a NovaPlay!\n\nTu registro fue exitoso.\n\nTu nombre de usuario es: {nombreUsuario}",
                        IsBodyHtml = false
                    };

                    await client.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error enviando el correo: {ex.Message}");
            }
        }
    }
}
