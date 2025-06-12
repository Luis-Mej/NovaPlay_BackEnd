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
    public class HistorialReproduccionController : ControllerBase
    {
        private readonly HistorialReproduccionServicios _servicio;

        public HistorialReproduccionController(HistorialReproduccionServicios servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        => Ok(await _servicio.GetAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HistorialReproduccionMS dto)
            => Ok(await _servicio.PostAsync(dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => Ok(await _servicio.DeleteAsync(id));
    }
}
