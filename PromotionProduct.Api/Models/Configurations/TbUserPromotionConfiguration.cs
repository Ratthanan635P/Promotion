using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PromotionProduct.Api.Models.Configurations
{
	public class TbUserPromotionConfiguration:IEntityTypeConfiguration<UserPromotionModel>
	{	
		public void Configure(EntityTypeBuilder<UserPromotionModel> builder)
		{

			builder.ToTable("Tb_UserPromotion");

			builder.Property(e => e.History).HasColumnName("history");

			builder.Property(e => e.Id).ValueGeneratedOnAdd();

			builder.Property(e => e.PromotionId).HasColumnName("promotionId");

			builder.Property(e => e.Status).HasColumnName("status");

			builder.Property(e => e.UserId).HasColumnName("userId");
			//builder.HasOne(e => e.Id)
		   //.WithMany()
		   //.HasForeignKey(s => s.CurrentGradeId);
		}
	}
}
