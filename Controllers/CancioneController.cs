using Dtos.DtosEntrada;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocio.Servicios;

namespace NovaPlay_BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CancioneController : ControllerBase
    {
        private readonly CancionServicios _servicio;

        public CancioneController(CancionServicios servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => Ok(await _servicio.GetAsync());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CancioneME dto) => Ok(await _servicio.PostAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CancioneME dto)
    => Ok(await _servicio.PutAsync(id, dto));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _servicio.DeleteAsync(id));
    }
}
