using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PromotionProduct.Api.Models.Configurations
{
	public class TbPromotionProductConfiguration : IEntityTypeConfiguration<TbPromotionProduct>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TbPromotionProduct> builder)
		{

			   builder.ToTable("Tb_PromotionProduct");

			   builder.Property(e => e.Detail).IsRequired();

			   builder.Property(e => e.Expire).HasColumnType("datetime");

			  builder.Property(e => e.Id).ValueGeneratedOnAdd();

			  builder.Property(e => e.Image).IsRequired();

			  builder.Property(e => e.Status).HasColumnName("status");

			  builder.Property(e => e.Title).IsRequired();
			
		}
	}
}
