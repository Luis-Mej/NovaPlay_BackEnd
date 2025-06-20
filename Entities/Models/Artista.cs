using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Artista
{
    public int IdArtista { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Albume> Albumes { get; set; } = new List<Albume>();

    public virtual ICollection<Cancione> Canciones { get; set; } = new List<Cancione>();
}
