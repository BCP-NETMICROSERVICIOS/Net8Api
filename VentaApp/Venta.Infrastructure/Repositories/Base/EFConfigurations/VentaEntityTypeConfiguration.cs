using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Venta.Domain.Models;


namespace Venta.Infrastructure.Repositories.Base.EFConfigurations
{
    public class VentaEntityTypeConfiguration
     : IEntityTypeConfiguration<Domain.Models.Venta>, IEntityTypeConfiguration<VentaDetalle> 
    {
        public void Configure(EntityTypeBuilder<Domain.Models.Venta> builder)
        {
            builder.ToTable("Venta");
            builder.HasKey(c => c.IdVenta);
            builder.HasOne(p => p.Cliente).WithMany(p => p.Ventas).HasForeignKey(p => p.IdCliente);
            //builder.HasOne(p => p.Cliente).WithMany(p =>p.Ventas).HasForeignKey(p => p.IdPago);
      
            builder.Property(p => p.Monto).HasPrecision(10, 2);

        }
        public void Configure(EntityTypeBuilder<VentaDetalle> builder)
        {
            builder.ToTable("VentaDetalle");
            builder.HasKey(c => c.IdVentaDetalle);

            builder.Property(p => p.Precio).HasPrecision(10, 2);
            builder.Property(p => p.SubTotal).HasPrecision(10, 2);
            builder.HasOne(p => p.Venta).WithMany(p => p.Detalle).HasForeignKey(p => p.IdVenta);
            builder.HasOne(p => p.Producto).WithMany(p => p.VentaDetalles).HasForeignKey(p => p.IdProducto);
           

        }


      



    }
}
