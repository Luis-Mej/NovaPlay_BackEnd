using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class PlaylistCancione
{
    public int IdPlaylistCancion { get; set; }

    public int? IdPlaylist { get; set; }

    public int? IdCancion { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cancione? IdCancionNavigation { get; set; }

    public virtual Playlist? IdPlaylistNavigation { get; set; }
}
