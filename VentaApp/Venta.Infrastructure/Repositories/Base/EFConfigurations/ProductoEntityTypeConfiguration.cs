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
    public class ProductoEntityTypeConfiguration
	: IEntityTypeConfiguration<Producto>
	{
		public void Configure(EntityTypeBuilder<Producto> builder)
		{

            builder.ToTable("Producto");

            builder.HasKey(c => c.IdProducto);

            builder.Property(c => c.Nombre);
            builder.Property(c => c.PrecioUnitario).HasPrecision(10, 2);
            builder.Property(c => c.Stock);
            builder.Property(c => c.StockMinimo);
          
            builder.HasOne(p => p.Categoria).WithMany(p => p.Productos)
                 .HasForeignKey(p => p.IdCategoria);
           


            //builder.ToTable("Producto");
            //builder.HasKey(c => c.IdProducto);
            //builder.Property(c => c.PrecioUnitario).HasPrecision(2);

            //builder.HasOne(p => p.Categoria).WithMany(p => p.Productos)
            //	.HasForeignKey(p => p.IdCategoria);
        }
    }
}
