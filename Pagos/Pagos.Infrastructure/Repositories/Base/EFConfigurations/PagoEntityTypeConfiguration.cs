using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagos.Domain.Models;

namespace Pagos.Infrastructure.Repositories.Base.EFConfigurations
{
    public class PagoEntityTypeConfiguration
    : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {

            builder.ToTable("PagoDetalle");

            builder.HasKey(c => c.IdPago);
            //   builder.HasOne(p => p.Cliente).WithMany(p => p.Pagos).HasForeignKey(p => p.IdCliente);
           // builder.Property(c => c.).HasPrecision(10, 2);
            builder.Property(c => c.Monto).HasPrecision(10, 2);



        }
        //public void Configure(EntityTypeBuilder<Tarjeta> builder)
        //{
        //    builder.ToTable("Tarjeta");
        //    builder.HasKey(c => c.IdPago);


        //    builder.HasOne(p => p.Pago).WithMany(p => p.Tarjetas).HasForeignKey(p => p.IdTarjeta);
        //  //  builder.HasOne(p => p.Producto).WithMany(p => p.VentaDetalles).HasForeignKey(p => p.IdProducto);
        //}
    }
}
