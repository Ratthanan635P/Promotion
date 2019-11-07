using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PromotionProduct.Api.Models.Configurations
{
	public class TbUserConfiguration : IEntityTypeConfiguration<TbUser>
	{
		public void Configure(EntityTypeBuilder<TbUser> Builder)
		{
			
			Builder.ToTable("Tb_User");

			Builder.Property(e => e.Email)
				.HasColumnName("email")
				.HasMaxLength(50);

			Builder.Property(e => e.Id).ValueGeneratedOnAdd();

			Builder.Property(e => e.Password)
				.HasColumnName("password")
				.HasMaxLength(50);

			Builder.Property(e => e.Status).HasColumnName("status");
			
		}
	}
}
