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
	public class ClienteEntityTypeConfiguration
		: IEntityTypeConfiguration<Cliente>
	{
		public void Configure(EntityTypeBuilder<Cliente> builder)
		{
			builder.ToTable("Cliente");
			builder.HasKey(c => c.IdCliente);
		}
	}
}
