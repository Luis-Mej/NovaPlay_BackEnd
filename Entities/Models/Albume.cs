using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Albume
{
    public int IdAlbum { get; set; }

    public string? Nombre { get; set; }

    public int? IdArtista { get; set; }

    public int? AnioLanzamiento { get; set; }

    public string? Portada { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Cancione> Canciones { get; set; } = new List<Cancione>();

    public virtual Artista? IdArtistaNavigation { get; set; }
}
