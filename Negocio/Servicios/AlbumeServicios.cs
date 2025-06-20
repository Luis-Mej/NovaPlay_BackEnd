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
    public class AlbumeServicios
    {
        private readonly NovaplayDbContext _context;

        public AlbumeServicios(NovaplayDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<List<AlbumMS>>> GetAsync()
        {
            var lista = await _context.Albumes
                .Where(a => a.Estado == "A")
                .Include(a => a.IdArtistaNavigation)
                .Include(a => a.Canciones.Where(c => c.Estado == "A"))
                .Select(a => new AlbumMS
                {
                    IdAlbum = a.IdAlbum,
                    Nombre = a.Nombre,
                    IdArtista = a.IdArtista,
                    AnioLanzamiento = a.AnioLanzamiento,
                    Portada = a.Portada,
                    NombreArtista = a.IdArtistaNavigation.Nombre,
                    Canciones = a.Canciones.Select(c => new PlaylistCancionesMS
                    {
                        IdCancion = c.IdCancion,
                        NombreCancion = c.Nombre
                    }).ToList()
                })
                .ToListAsync();

            return new ResponseBase<List<AlbumMS>>(200, lista);
        }

        public async Task<ResponseBase<string>> PostAsync(AlbumMS dto)
        {
            var entity = new Albume
            {
                Nombre = dto.Nombre,
                IdArtista = dto.IdArtista,
                AnioLanzamiento = dto.AnioLanzamiento,
                Portada = dto.Portada,
                Estado = "A"
            };

            _context.Albumes.Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Álbum registrado");
        }

        public async Task<ResponseBase<string>> PutAsync(int id, AlbumMS dto)
        {
            var entity = await _context.Albumes.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Álbum no encontrado");

            entity.Nombre = dto.Nombre;
            entity.IdArtista = dto.IdArtista;
            entity.AnioLanzamiento = dto.AnioLanzamiento;
            entity.Portada = dto.Portada;

            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Álbum actualizado");
        }

        public async Task<ResponseBase<string>> DeleteAsync(int id)
        {
            var entity = await _context.Albumes.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Álbum no encontrado");

            entity.Estado = "I";
            await _context.SaveChangesAsync();

            return new ResponseBase<string>(200, "Álbum eliminado");
        }
    }
}
