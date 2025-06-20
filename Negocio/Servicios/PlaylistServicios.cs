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
    public class PlaylistServicios
    {
        private readonly NovaplayDbContext _context;

        public PlaylistServicios(NovaplayDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<List<PlaylistMS>>> GetAsync()
        {
            var lista = await _context.Playlists
                .Where(p => p.Estado == "A")
                .Include(p => p.PlaylistCanciones.Where(pc => pc.Estado == "A"))
                    .ThenInclude(pc => pc.IdCancionNavigation)
                .Select(p => new PlaylistMS
                {
                    IdPlaylist = p.IdPlaylist,
                    Nombre = p.Nombre,
                    IdUsuario = p.IdUsuario,
                    Portada = p.Portada,
                    PlaylistCanciones = p.PlaylistCanciones.Select(pc => new PlaylistCancionesMS
                    {
                        IdPlaylistCancion = pc.IdPlaylistCancion,
                        IdPlaylist = pc.IdPlaylist,
                        IdCancion = pc.IdCancion,
                        NombreCancion = pc.IdCancionNavigation.Nombre,
                    }).ToList()
                })
                .ToListAsync();

            return new ResponseBase<List<PlaylistMS>>(200, lista);
        }

        public async Task<ResponseBase<string>> PostAsync(PlaylistMS dto)
        {
            var entity = new Playlist
            {
                Nombre = dto.Nombre,
                IdUsuario = dto.IdUsuario,
                Portada = dto.Portada,
                Estado = "A"
            };

            _context.Playlists.Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Playlist registrada");
        }

        public async Task<ResponseBase<string>> PutAsync(int id, PlaylistMS dto)
        {
            var entity = await _context.Playlists.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Playlist no encontrada");

            entity.Nombre = dto.Nombre;
            entity.IdUsuario = dto.IdUsuario;
            entity.Portada = dto.Portada;

            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Playlist actualizada");
        }

        public async Task<ResponseBase<string>> DeleteAsync(int id)
        {
            var entity = await _context.Playlists.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Playlist no encontrada");

            entity.Estado = "I";
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Playlist eliminada");
        }
    }
}
