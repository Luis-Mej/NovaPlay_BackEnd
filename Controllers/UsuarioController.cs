using Dtos.DtosEntrada;
using Dtos.DtosSalida;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Servicios;

namespace NovaPlay_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioServicios;

        public UsuarioController(UsuarioService usuarioServicios)
        {
            _usuarioServicios = usuarioServicios;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        => Ok(await _usuarioServicios.GetUsuariosAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioME dto)
            => Ok(await _usuarioServicios.CrearUsuarioAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UsuarioME dto)
            => Ok(await _usuarioServicios.ActualizarUsuarioAsync(id, dto));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _usuarioServicios.EliminarUsuarioAsync(id));

    }
}
