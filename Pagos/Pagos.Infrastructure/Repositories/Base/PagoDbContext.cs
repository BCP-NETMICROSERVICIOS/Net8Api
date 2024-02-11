using Microsoft.EntityFrameworkCore;
using Pagos.Domain.Models;

namespace Pagos.Infrastructure.Repositories.Base
{
    public class PagoDbContext : DbContext
    {
        /// <summary>
        /// Configurando el aceso a la base de datos
        /// </summary>
        /// <param name="options"></param>
        public PagoDbContext(DbContextOptions<PagoDbContext> options)
            : base(options)
        {

        }


        public virtual DbSet<Pago> Pagos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            #region Configuraando las entidades en archivos de tipos separados
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PagoDbContext).Assembly);
            #endregion

            #region Configuracion de las entidades en el mismo ModelCreating
            //modelBuilder.Entity<Pago>(
            //    p =>
            //    {
            //        p.ToTable("Pago");
            //        p.HasKey(c => c.IdPago);
            //      //  p.Property(p => p.Nombre).HasColumnName("Nombre");
            //    }
            //    );


            //modelBuilder.Entity<Pago>(
            //    p =>
            //    {
            //        p.ToTable("Pago");
            //        p.HasKey(c => c.IdPago);
            //    }
            //    );

            //modelBuilder.Entity<Producto>(
            //    p =>
            //    {
            //        p.ToTable("Producto");
            //        p.HasKey(c => c.IdProducto);
            //        p.Property(c => c.PrecioUnitario).HasPrecision(2);

            //        p.HasOne(p => p.Categoria).WithMany(p => p.Productos)
            //            .HasForeignKey(p => p.IdCategoria);
            //    }                
            //    );


            //modelBuilder.Entity<Domain.Models.Venta>(
            //   p =>
            //   {
            //       p.ToTable("Venta");
            //       p.HasKey(c => c.IdVenta);

            //       p.HasOne(p => p.Cliente).WithMany(p => p.Ventas)
            //            .HasForeignKey(p => p.IdCliente);
            //   }
            //   );


            //modelBuilder.Entity<Domain.Models.VentaDetalle>(
            //   p =>
            //   {
            //       p.ToTable("VentaDetalle");
            //       p.HasKey(c => c.IdVentaDetalle);

            //       p.HasOne(p => p.Venta).WithMany(p => p.Detalle)
            //            .HasForeignKey(p => p.IdVenta);

            //       p.HasOne(p => p.Producto).WithMany(p => p.VentaDetalles)
            //           .HasForeignKey(p => p.IdProducto);
            //   }
            //   );

            #endregion


        }

    }
}
