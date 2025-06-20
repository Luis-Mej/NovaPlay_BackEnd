using Dtos;
using Dtos.DtosEntrada;
using Dtos.DtosSalida;
using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Negocio.Servicios
{
    public class CancionServicios
    {
        private readonly NovaplayDbContext _context;

        public CancionServicios(NovaplayDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<List<CancioneMS>>> GetAsync()
        {
            var lista = await _context.Canciones
                .Where(c => c.Estado == "A")
                .Include(c => c.IdArtistaNavigation)
                .Include(c => c.IdAlbumNavigation)
                .Select(c => new CancioneMS
                {
                    IdCancion = c.IdCancion,
                    Nombre = c.Nombre,
                    IdArtista = c.IdArtista,
                    IdAlbum = c.IdAlbum,
                    Duracion = c.Duracion,
                    Archivo = c.Archivo,
                    Genero = c.Genero,
                    NombreArtista = c.IdArtistaNavigation.Nombre,
                    NombreAlbum = c.IdAlbumNavigation.Nombre
                })
                .ToListAsync();

            return new ResponseBase<List<CancioneMS>>(200, lista);
        }

        public async Task<ResponseBase<string>> PostAsync(CancioneME dto)
        {
            var entity = new Cancione
            {
                Nombre = dto.Nombre,
                IdArtista = dto.IdArtista,
                IdAlbum = dto.IdAlbum,
                Duracion = dto.Duracion,
                Archivo = dto.Archivo,
                Genero = dto.Genero,
                Estado = "A"
            };

            _context.Canciones.Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Canción registrada");
        }

        public async Task<ResponseBase<string>> PutAsync(int id, CancioneME dto)
        {
            var entity = await _context.Canciones.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Canción no encontrada");

            entity.Nombre = dto.Nombre;
            entity.IdArtista = dto.IdArtista;
            entity.IdAlbum = dto.IdAlbum;
            entity.Duracion = dto.Duracion;
            entity.Archivo = dto.Archivo;
            entity.Genero = dto.Genero;

            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Canción actualizada");
        }

        public async Task<ResponseBase<string>> DeleteAsync(int id)
        {
            var entity = await _context.Canciones.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Canción no encontrada");

            entity.Estado = "I";
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Canción eliminada");
        }
    }
}
