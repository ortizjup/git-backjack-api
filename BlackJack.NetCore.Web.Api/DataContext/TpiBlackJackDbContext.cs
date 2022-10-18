using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BlackJack.NetCore.Web.Api.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BlackJack.NetCore.Web.Api.DataContext
{
    public partial class TpiBlackJackDbContext : DbContext
    {
        public TpiBlackJackDbContext()
        {
        }

        public TpiBlackJackDbContext(DbContextOptions<TpiBlackJackDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cartas> Cartas { get; set; }
        public virtual DbSet<Juegos> Juegos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosCartasJuegos> UsuariosCartasJuegos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=tpi-blackjack-db-dev.mysql.database.azure.com;port=3306;user=BlackJackAdmin;password=MeGustaLaTimba2022;database=tpi-blackjack-dev");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cartas>(entity =>
            {
                entity.HasKey(e => e.IdCarta)
                    .HasName("PRIMARY");

                entity.ToTable("cartas");

                entity.Property(e => e.IdCarta)
                    .HasColumnName("id_carta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasMaxLength(2);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasColumnName("descripcion")
                    .HasMaxLength(50);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Juegos>(entity =>
            {
                entity.HasKey(e => e.IdJuego)
                    .HasName("PRIMARY");

                entity.ToTable("juegos");

                entity.Property(e => e.IdJuego)
                    .HasColumnName("id_juego")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo)
                    .IsRequired()
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasColumnName("apellido")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.HashContraseña)
                    .IsRequired()
                    .HasColumnName("hashContraseña")
                    .HasColumnType("binary(50)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UsuariosCartasJuegos>(entity =>
            {
                entity.HasKey(e => e.IdCombination)
                    .HasName("PRIMARY");

                entity.ToTable("usuarios_cartas_juegos");

                entity.HasIndex(e => e.IdCarta)
                    .HasName("id_carta_idx");

                entity.HasIndex(e => e.IdJuego)
                    .HasName("Usuarios_Cartas_Juegos_Juegos_idx");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("Usuarios_Cartas_Juegos_Usuarios_idx");

                entity.Property(e => e.IdCombination)
                    .HasColumnName("id_combination")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCarta)
                    .HasColumnName("id_carta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdJuego)
                    .HasColumnName("id_juego")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCartaNavigation)
                    .WithMany(p => p.UsuariosCartasJuegos)
                    .HasForeignKey(d => d.IdCarta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuarios_Cartas_Juegos_Cartas");

                entity.HasOne(d => d.IdJuegoNavigation)
                    .WithMany(p => p.UsuariosCartasJuegos)
                    .HasForeignKey(d => d.IdJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuarios_Cartas_Juegos_Juegos");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosCartasJuegos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuarios_Cartas_Juegos_Usuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
