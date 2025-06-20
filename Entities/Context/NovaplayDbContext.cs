using System;
using System.Collections.Generic;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.Context;

public partial class NovaplayDbContext : DbContext
{
    public NovaplayDbContext()
    {
    }

    public NovaplayDbContext(DbContextOptions<NovaplayDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Albume> Albumes { get; set; }

    public virtual DbSet<Artista> Artistas { get; set; }

    public virtual DbSet<Cancione> Canciones { get; set; }

    public virtual DbSet<HistorialReproduccion> HistorialReproduccions { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<PlaylistCancione> PlaylistCanciones { get; set; }

    public virtual DbSet<RecomendacionesIum> RecomendacionesIa { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Albume>(entity =>
        {
            entity.HasKey(e => e.IdAlbum).HasName("PK__ALBUMES__36B391E2EF2648F0");

            entity.ToTable("ALBUMES");

            entity.Property(e => e.IdAlbum).HasColumnName("ID_ALBUM");
            entity.Property(e => e.AnioLanzamiento).HasColumnName("ANIO_LANZAMIENTO");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A");
            entity.Property(e => e.IdArtista).HasColumnName("ID_ARTISTA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Portada)
                .HasMaxLength(255)
                .HasColumnName("PORTADA");

            entity.HasOne(d => d.IdArtistaNavigation).WithMany(p => p.Albumes)
                .HasForeignKey(d => d.IdArtista)
                .HasConstraintName("FK__ALBUMES__ID_ARTI__3C69FB99");
        });

        modelBuilder.Entity<Artista>(entity =>
        {
            entity.HasKey(e => e.IdArtista).HasName("PK__ARTISTAS__2ADEC5CCD56F533C");

            entity.ToTable("ARTISTAS");

            entity.Property(e => e.IdArtista).HasColumnName("ID_ARTISTA");
            entity.Property(e => e.Descripcion).HasColumnName("DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A");
            entity.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("IMAGEN");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
        });

        modelBuilder.Entity<Cancione>(entity =>
        {
            entity.HasKey(e => e.IdCancion).HasName("PK__CANCIONE__10FC28B3BA5B78DC");

            entity.ToTable("CANCIONES");

            entity.Property(e => e.IdCancion).HasColumnName("ID_CANCION");
            entity.Property(e => e.Archivo)
                .HasMaxLength(255)
                .HasColumnName("ARCHIVO");
            entity.Property(e => e.Duracion).HasColumnName("DURACION");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A");
            entity.Property(e => e.Genero)
                .HasMaxLength(50)
                .HasColumnName("GENERO");
            entity.Property(e => e.IdAlbum).HasColumnName("ID_ALBUM");
            entity.Property(e => e.IdArtista).HasColumnName("ID_ARTISTA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdAlbumNavigation).WithMany(p => p.Canciones)
                .HasForeignKey(d => d.IdAlbum)
                .HasConstraintName("FK__CANCIONES__ID_AL__403A8C7D");

            entity.HasOne(d => d.IdArtistaNavigation).WithMany(p => p.Canciones)
                .HasForeignKey(d => d.IdArtista)
                .HasConstraintName("FK__CANCIONES__ID_AR__3F466844");
        });

        modelBuilder.Entity<HistorialReproduccion>(entity =>
        {
            entity.HasKey(e => e.IdHistorial).HasName("PK__HISTORIA__9679F8A229905ACF");

            entity.ToTable("HISTORIAL_REPRODUCCION");

            entity.Property(e => e.IdHistorial).HasColumnName("ID_HISTORIAL");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A");
            entity.Property(e => e.FechaReproduccion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REPRODUCCION");
            entity.Property(e => e.IdCancion).HasColumnName("ID_CANCION");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

            entity.HasOne(d => d.Cancione).WithMany(p => p.HistorialReproduccions)
                .HasForeignKey(d => d.IdCancion)
                .HasConstraintName("FK__HISTORIAL__ID_CA__4BAC3F29");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialReproduccions)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__HISTORIAL__ID_US__4AB81AF0");
        });

        modelBuilder.Entity<Playlist>(entity =>
        {
            entity.HasKey(e => e.IdPlaylist).HasName("PK__PLAYLIST__3F0FA36C336630EE");

            entity.ToTable("PLAYLISTS");

            entity.Property(e => e.IdPlaylist).HasColumnName("ID_PLAYLIST");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Portada)
                .HasMaxLength(255)
                .HasColumnName("PORTADA");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Playlists)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__PLAYLISTS__ID_US__4316F928");
        });

        modelBuilder.Entity<PlaylistCancione>(entity =>
        {
            entity.HasKey(e => e.IdPlaylistCancion).HasName("PK__PLAYLIST__9638A27B38A7971F");

            entity.ToTable("PLAYLIST_CANCIONES");

            entity.Property(e => e.IdPlaylistCancion).HasColumnName("ID_PLAYLIST_CANCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A");
            entity.Property(e => e.IdCancion).HasColumnName("ID_CANCION");
            entity.Property(e => e.IdPlaylist).HasColumnName("ID_PLAYLIST");

            entity.HasOne(d => d.IdCancionNavigation).WithMany(p => p.PlaylistCanciones)
                .HasForeignKey(d => d.IdCancion)
                .HasConstraintName("FK__PLAYLIST___ID_CA__46E78A0C");

            entity.HasOne(d => d.IdPlaylistNavigation).WithMany(p => p.PlaylistCanciones)
                .HasForeignKey(d => d.IdPlaylist)
                .HasConstraintName("FK__PLAYLIST___ID_PL__45F365D3");
        });

        modelBuilder.Entity<RecomendacionesIum>(entity =>
        {
            entity.HasKey(e => e.IdRecomendacion).HasName("PK__RECOMEND__91C9B5C6604FEEFF");

            entity.ToTable("RECOMENDACIONES_IA");

            entity.Property(e => e.IdRecomendacion).HasColumnName("ID_RECOMENDACION");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA");
            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Prompt).HasColumnName("PROMPT");
            entity.Property(e => e.Recomendacion).HasColumnName("RECOMENDACION");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.RecomendacionesIa)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__RECOMENDA__ID_US__4F7CD00D");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__USUARIOS__91136B9012388B6D");

            entity.ToTable("USUARIOS");

            entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");
            entity.Property(e => e.Avatar)
                .HasMaxLength(255)
                .HasColumnName("AVATAR");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(255)
                .HasColumnName("CONTRASENIA");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValue("A");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_REGISTRO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("NOMBRE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
