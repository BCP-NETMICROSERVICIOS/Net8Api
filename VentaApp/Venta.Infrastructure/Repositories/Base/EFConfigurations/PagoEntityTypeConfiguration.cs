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
    public class PagoEntityTypeConfiguration
	: IEntityTypeConfiguration<Pago>, IEntityTypeConfiguration<PagoDetalle>

    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pago");
            builder.HasKey(c => c.IdVenta);
           // builder.Ignore(c => c.IdVenta);
          //  builder.HasKey(c => c.IdVenta);
           // builder.HasOne(p => p.Cliente).WithMany(p => p.Venta).HasForeignKey(p => p.IdCliente);
        }
        public void Configure(EntityTypeBuilder<PagoDetalle> builder)
        {

            builder.ToTable("PagoDetalle");
            builder.HasKey(c => c.IdPago);

        //    builder.HasOne(p => p.Venta).WithMany(p => p.Pago).HasForeignKey(p => p.IdVenta);
       // builder.HasOne(p => p.Producto).WithMany(p => p.VentaDetalles).HasForeignKey(p => p.IdProducto);
        }

       

 
    }
}
