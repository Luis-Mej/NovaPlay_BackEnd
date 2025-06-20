using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class RecomendacionesIum
{
    public int IdRecomendacion { get; set; }

    public int? IdUsuario { get; set; }

    public string? Prompt { get; set; }

    public string? Recomendacion { get; set; }

    public DateTime? Fecha { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
