using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class HistorialReproduccion
{
    public int IdHistorial { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdCancion { get; set; }

    public DateTime? FechaReproduccion { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Cancione? Cancione { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
