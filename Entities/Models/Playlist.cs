using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Playlist
{
    public int IdPlaylist { get; set; }

    public string? Nombre { get; set; }

    public int? IdUsuario { get; set; }

    public string? Portada { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<PlaylistCancione> PlaylistCanciones { get; set; } = new List<PlaylistCancione>();
}
