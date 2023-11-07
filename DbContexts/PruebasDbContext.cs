using ApiPrueba.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPrueba.DbContexts
{
    public partial class PruebasDbContext : DbContext
    {
        public PruebasDbContext()
        {
        }

        public PruebasDbContext(DbContextOptions<PruebasDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HistorialRefreshToken> HistorialRefreshTokens { get; set; }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Token> Tokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistorialRefreshToken>(entity =>
            {
                entity.HasKey(e => e.IdHistorialToken).HasName("PK__Historia__03DC48A5BDFD22AD");

                entity.ToTable("HistorialRefreshToken");

                entity.Property(e => e.EsActivo).HasComputedColumnSql("(case when [FechaExpiracion]<getdate() then CONVERT([bit],(0)) else CONVERT([bit],(1)) end)", false);
                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
                entity.Property(e => e.FechaExpiracion).HasColumnType("datetime");
                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(200)
                    .IsUnicode(false);
                entity.Property(e => e.Token)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.HistorialRefreshTokens)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Historial__IdUsu__24927208");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}