using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class Usuario
{
    public Usuario()
    {
    }

    public Usuario(int idUsuario, string? nombre, string? email, string? contrasenia, string? avatar, DateTime? fechaRegistro, string estado, ICollection<HistorialReproduccion> historialReproduccions, ICollection<Playlist> playlists, ICollection<RecomendacionesIum> recomendacionesIa)
    {
        IdUsuario = idUsuario;
        Nombre = nombre;
        Email = email;
        Contrasenia = contrasenia;
        Avatar = avatar;
        FechaRegistro = fechaRegistro;
        Estado = estado;
        HistorialReproduccions = historialReproduccions;
        Playlists = playlists;
        RecomendacionesIa = recomendacionesIa;
    }

    public int IdUsuario { get; set; }

    public string? Nombre { get; set; }

    public string? Email { get; set; }

    public string? Contrasenia { get; set; }

    public string? Avatar { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<HistorialReproduccion> HistorialReproduccions { get; set; } = new List<HistorialReproduccion>();

    public virtual ICollection<Playlist> Playlists { get; set; } = new List<Playlist>();

    public virtual ICollection<RecomendacionesIum> RecomendacionesIa { get; set; } = new List<RecomendacionesIum>();
}
