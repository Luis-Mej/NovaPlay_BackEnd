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
    public class PlaylistCancioneServicios
    {
        private readonly NovaplayDbContext _context;

        public PlaylistCancioneServicios(NovaplayDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<List<PlaylistCancionesMS>>> GetAsync()
        {
            var lista = await _context.PlaylistCanciones
                .Where(pc => pc.Estado == "A")
                .Include(pc => pc.IdCancionNavigation)
                .Select(pc => new PlaylistCancionesMS
                {
                    IdPlaylistCancion = pc.IdPlaylistCancion,
                    IdPlaylist = pc.IdPlaylist,
                    IdCancion = pc.IdCancion,
                    NombreCancion = pc.IdCancionNavigation.Nombre
                })
                .ToListAsync();

            return new ResponseBase<List<PlaylistCancionesMS>>(200, lista);
        }

        public async Task<ResponseBase<string>> PostAsync(PlaylistCancionesMS dto)
        {
            var entity = new PlaylistCancione
            {
                IdPlaylist = dto.IdPlaylist,
                IdCancion = dto.IdCancion,
                Estado = "A"
            };

            _context.PlaylistCanciones.Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Canción agregada a playlist");
        }

        public async Task<ResponseBase<string>> DeleteAsync(int id)
        {
            var entity = await _context.PlaylistCanciones.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Elemento no encontrado");

            entity.Estado = "I";
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Canción eliminada de la playlist");
        }
    }
}
