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
	: IEntityTypeConfiguration<PagoDetalle>, IEntityTypeConfiguration<Entrega>

    {
        public void Configure(EntityTypeBuilder<PagoDetalle> builder)
        {
            builder.ToTable("PagoDetalle");

            builder.HasKey(c => c.IdPago);
            builder.Property(c => c.IdPago).IsRequired().ValueGeneratedOnAdd();
          //  builder.HasOne(p => p.Venta).WithMany(p => p.Entrega).HasForeignKey(p => p.IdCliente);
            // builder.Property(c => c.).HasPrecision(10, 2);
          //  builder.Property(c => c.Monto).HasPrecision(10, 2);
        }
        public void Configure(EntityTypeBuilder<Entrega> builder)
        {

            builder.ToTable("Entrega");
            builder.HasKey(c => c.IdEntrega);
            builder.Property(c => c.IdEntrega).IsRequired().ValueGeneratedOnAdd();
          //  builder.HasOne(c => c.PagoDetalle ).WithMany(c => c.Entregas).HasForeignKey(c => c.IdPago);
        }

       

 
    }
}
