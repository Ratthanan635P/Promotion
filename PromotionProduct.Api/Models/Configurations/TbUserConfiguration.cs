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
		public void Configure(EntityTypeBuilder<TbUser> entity)
		{
			entity.HasNoKey();

			entity.ToTable("Tb_User");

			entity.Property(e => e.Email)
				.HasColumnName("email")
				.HasMaxLength(50);

			entity.Property(e => e.Id).ValueGeneratedOnAdd();

			entity.Property(e => e.Password)
				.HasColumnName("password")
				.HasMaxLength(50);

			entity.Property(e => e.Status).HasColumnName("status");
		}
	}
}
