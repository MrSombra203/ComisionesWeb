
using Microsoft.EntityFrameworkCore;
using ComisionesWeb.Models;
using ComisionesWeb.ViewModels;

namespace ComisionesWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Vendedor> Vendedor => Set<Vendedor>();
        public DbSet<Regla> Reglas => Set<Regla>();
        public DbSet<Venta> Ventas => Set<Venta>();

        // Tablas virtuales para mapear resultados de SPs
        public DbSet<ComisionDetalleRow> ComisionDetalle => Set<ComisionDetalleRow>();
        public DbSet<ResumenComisionesRow> ResumenComisiones => Set<ResumenComisionesRow>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Vendedor)
                .WithMany()
                .HasForeignKey(v => v.VendedorId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Regla)
                .WithMany()
                .HasForeignKey(v => v.ReglaId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ComisionDetalleRow>().HasNoKey();
            modelBuilder.Entity<ResumenComisionesRow>().HasNoKey();
        }
    }
}
