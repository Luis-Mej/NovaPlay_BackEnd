using Dtos.DtosEntrada;
using Microsoft.AspNetCore.Mvc;
using Negocio.Servicios;

namespace NovaPlay_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginServicios _loginServicios;

        public LoginController(LoginServicios loginServicios)
        {
            _loginServicios = loginServicios;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginME loginDto)
        {
            var respuesta = await _loginServicios.Login(loginDto);

            if (respuesta.StatusCode != 200)
                return BadRequest(respuesta);

            return Ok(respuesta);
        }
    }
}
