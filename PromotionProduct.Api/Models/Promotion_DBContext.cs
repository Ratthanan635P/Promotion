using System;
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

        public virtual DbSet<TbPromotionProduct> TbPromotionProduct { get; set; }
        public virtual DbSet<TbUser> TbUser { get; set; }
        public virtual DbSet<TbUserPromotion> TbUserPromotion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Promotion_DB;Trusted_Connection=True;User Id=sa;Password=yourStrong(!)Password;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            //modelBuilder.Entity<TbUser>(entity =>
            //{
            //    entity.HasNoKey();

            //    entity.ToTable("Tb_User");

            //    entity.Property(e => e.Email)
            //        .HasColumnName("email")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //    entity.Property(e => e.Password)
            //        .HasColumnName("password")
            //        .HasMaxLength(50);

            //    entity.Property(e => e.Status).HasColumnName("status");
            //});

            modelBuilder.Entity<TbUserPromotion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Tb_UserPromotion");

                entity.Property(e => e.History).HasColumnName("history");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.PromotionId).HasColumnName("promotionId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
