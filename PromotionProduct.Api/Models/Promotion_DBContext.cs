using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PromotionProduct.Api.Models
{
    public partial class Promotion_DBContext : DbContext
    {
        public Promotion_DBContext()
        {
        }

        public Promotion_DBContext(DbContextOptions<Promotion_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PromotionProductModel> Tb_PromotionProduct { get; set; }
        public virtual DbSet<UserModel> Tb_User { get; set; }
        public virtual DbSet<UserPromotionModel> Tb_UserPromotion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder.UseSqlServer("Server=localhost;Database=Promotion_DB;Trusted_Connection=True;User Id=sa;Password=yourStrong(!)Password;Integrated Security=false;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());	
		}
    }
}
