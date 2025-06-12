using Dtos.DtosEntrada;
using Dtos.DtosSalida;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Servicios;


namespace NovaPlay_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlaylistController : ControllerBase
    {
        private readonly PlaylistServicios _servicio;

        public PlaylistController(PlaylistServicios servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        => Ok(await _servicio.GetAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlaylistMS dto)
            => Ok(await _servicio.PostAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlaylistMS dto)
            => Ok(await _servicio.PutAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _servicio.DeleteAsync(id));
    }
}
