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
    public class ArtistaServicios
    {
        private readonly NovaplayDbContext _context;

        public ArtistaServicios(NovaplayDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseBase<List<ArtistaMS>>> GetAsync()
        {
            var lista = await _context.Artistas
                .Where(a => a.Estado == "A")
                .Include(a => a.Albumes)
                .Select(a => new ArtistaMS
                {
                    IdArtista = a.IdArtista,
                    Nombre = a.Nombre,
                    Descripcion = a.Descripcion,
                    Imagen = a.Imagen,
                    AlbumesIds = a.Albumes.Where(al => al.Estado == "A").Select(al => al.IdAlbum).ToList()
                })
                .ToListAsync();

            return new ResponseBase<List<ArtistaMS>>(200, lista);
        }

        public async Task<ResponseBase<string>> PostAsync(ArtistaMS dto)
        {
            var entity = new Artista
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Imagen = dto.Imagen,
                Estado = "A"
            };

            _context.Artistas.Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Artista registrado");
        }

        public async Task<ResponseBase<string>> PutAsync(int id, ArtistaMS dto)
        {
            var entity = await _context.Artistas.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Artista no encontrado");

            entity.Nombre = dto.Nombre;
            entity.Descripcion = dto.Descripcion;
            entity.Imagen = dto.Imagen;

            await _context.SaveChangesAsync();
            return new ResponseBase<string>(200, "Artista actualizado");
        }

        public async Task<ResponseBase<string>> DeleteAsync(int id)
        {
            var entity = await _context.Artistas.FindAsync(id);
            if (entity == null || entity.Estado != "A")
                return new ResponseBase<string>(404, "Artista no encontrado");

            entity.Estado = "I";
            await _context.SaveChangesAsync();

            return new ResponseBase<string>(200, "Artista eliminado");
        }
    }
}
