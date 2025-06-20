using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Cancione
{
    public int IdCancion { get; set; }

    public string? Nombre { get; set; }

    public int? IdArtista { get; set; }

    public int? IdAlbum { get; set; }

    public TimeOnly? Duracion { get; set; }

    public string? Archivo { get; set; }

    public string? Genero { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<HistorialReproduccion> HistorialReproduccions { get; set; } = new List<HistorialReproduccion>();

    public virtual Albume? IdAlbumNavigation { get; set; }

    public virtual Artista? IdArtistaNavigation { get; set; }

    public virtual ICollection<PlaylistCancione> PlaylistCanciones { get; set; } = new List<PlaylistCancione>();
}
