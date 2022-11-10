using BlackJack.NetCore.Web.Api.Models;
using Microsoft.EntityFrameworkCore;

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
        public virtual DbSet<CartasValores> CartasValores { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<DetallesJuego> DetallesJuego { get; set; }
        public virtual DbSet<Juegos> Juegos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Valores> Valores { get; set; }

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

                entity.HasIndex(e => e.IdCategoria)
                    .HasName("Cartas_Categorias_idx");

                entity.Property(e => e.IdCarta)
                    .HasColumnName("id_carta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasColumnName("codigo")
                    .HasColumnType("varchar(2)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShowBack)
                    .HasColumnName("showBack")
                    .HasColumnType("bit(1)")
                    .HasConversion<bool>();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Cartas)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Cartas_Categorias");
            });

            modelBuilder.Entity<CartasValores>(entity =>
            {
                entity.HasKey(e => e.IdCartavalores)
                    .HasName("PRIMARY");

                entity.ToTable("cartas_valores");

                entity.HasIndex(e => e.IdCarta)
                    .HasName("CartasValores_Cartas_idx");

                entity.HasIndex(e => e.IdValor)
                    .HasName("CartaValores_Valores_idx");

                entity.Property(e => e.IdCartavalores)
                    .HasColumnName("id_cartavalores")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdCarta)
                    .HasColumnName("id_carta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdValor)
                    .HasColumnName("id_valor")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCartaNavigation)
                    .WithMany(p => p.CartasValores)
                    .HasForeignKey(d => d.IdCarta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CartasValores_Cartas");

                entity.HasOne(d => d.IdValorNavigation)
                    .WithMany(p => p.CartasValores)
                    .HasForeignKey(d => d.IdValor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CartaValores_Valores");
            });

            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categorias");

                entity.Property(e => e.IdCategoria)
                    .HasColumnName("id_categoria")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .HasColumnType("varchar(2)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NewTablecol)
                    .HasColumnName("new_tablecol")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<DetallesJuego>(entity =>
            {
                entity.HasKey(e => e.IdDetalleJuego)
                    .HasName("PRIMARY");

                entity.ToTable("detalles_juego");

                entity.HasIndex(e => e.IdCarta)
                    .HasName("DetallesJuego_Cartas_idx");

                entity.HasIndex(e => e.IdJuego)
                    .HasName("Usuarios_Cartas_Juegos_Juegos_idx");

                entity.Property(e => e.IdDetalleJuego)
                    .HasColumnName("id_detalle_juego")
                    .HasColumnType("int(11)");

                entity.Property(e => e.EsCartaCrupier)
                    .HasColumnName("esCartaCrupier")
                    .HasColumnType("bit(1)")
                    .HasConversion<bool>();

                entity.Property(e => e.IdCarta)
                    .HasColumnName("id_carta")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdJuego)
                    .HasColumnName("id_juego")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ValorCarta)
                    .HasColumnName("valorCarta")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdCartaNavigation)
                    .WithMany(p => p.DetallesJuego)
                    .HasForeignKey(d => d.IdCarta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetallesJuego_Cartas");

                entity.HasOne(d => d.IdJuegoNavigation)
                    .WithMany(p => p.DetallesJuego)
                    .HasForeignKey(d => d.IdJuego)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("DetallesJuego_Juegos");
            });

            modelBuilder.Entity<Juegos>(entity =>
            {
                entity.HasKey(e => e.IdJuego)
                    .HasName("PRIMARY");

                entity.ToTable("juegos");

                entity.HasIndex(e => e.IdUsuario)
                    .HasName("Juegos_Usuarios_idx");

                entity.Property(e => e.IdJuego)
                    .HasColumnName("id_juego")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.GanoJugador)
                    .HasColumnName("ganoJugador")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.EsEmpate)
                   .HasColumnName("esEmpate")
                   .HasColumnType("bit(1)");

                entity.Property(e => e.IdUsuario)
                    .HasColumnName("id_usuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ScoreCrupier)
                    .HasColumnName("scoreCrupier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ScoreJugador)
                    .HasColumnName("scoreJugador")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Juegos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Juegos_Usuarios");
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
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(50)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasColumnName("passwordHash");

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasColumnName("passwordSalt");

                entity.Property(e => e.PhotoUrl)
                    .HasColumnName("photoUrl")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<Valores>(entity =>
            {
                entity.HasKey(e => e.IdValor)
                    .HasName("PRIMARY");

                entity.ToTable("valores");

                entity.HasComment("	");

                entity.Property(e => e.IdValor)
                    .HasColumnName("id_valor")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("int(11)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
