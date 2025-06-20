using Dtos;
using Dtos.DtosSalida;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class HistorialReproduccionServicios
    {
        private readonly NovaplayDbContext _context;

        public HistorialReproduccionServicios(NovaplayDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<List<HistorialReproduccionMS>>> GetAsync()
        {
            var lista = await _context.HistorialReproduccions
                .Where(h => h.Estado == "A")
                .Include(h => h.Cancione)
                .Select(h => new HistorialReproduccionMS
                {
                    IdHistorial = h.IdHistorial,
                    IdUsuario = h.IdUsuario,
                    IdCancion = h.IdCancion,
                    FechaReproduccion = h.FechaReproduccion,
                    NombreCancion = h.Cancione.Nombre
                })
                .ToListAsync();

            return new ResponseBase<List<HistorialReproduccionMS>>(200, lista);
        }

        public async Task<ResponseBase<string>> PostAsync(HistorialReproduccionMS dto)
        {
            var entity = new HistorialReproduccion
            {
                IdUsuario = dto.IdUsuario,
                IdCancion = dto.IdCancion,
                FechaReproduccion = dto.FechaReproduccion,
                Estado = "A"
            };

            _context.HistorialReproduccions.Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Reproducción registrada");
        }

        public async Task<ResponseBase<string>> DeleteAsync(int id)
        {
            var entity = await _context.HistorialReproduccions.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Historial no encontrado");

            entity.Estado = "I";
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Registro de historial eliminado");
        }
    }
}
