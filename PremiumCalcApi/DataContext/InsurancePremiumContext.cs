using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Options;
using PremiumCalcApi.Common;
using PremiumCalcApi.DataContext;

#nullable disable

namespace PremiumCalcApi.Models
{
    public partial class InsurancePremiumContext : DbContext
    {
        private readonly AppSettings _appSetting;

        public InsurancePremiumContext(IOptions<AppSettings> appSetting)
        {
            _appSetting = appSetting.Value;
        }

        public InsurancePremiumContext(DbContextOptions<InsurancePremiumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Factor> Factors { get; set; }
        public virtual DbSet<Occupation> Occupations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(_appSetting.SqlConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Factor>(entity =>
            {
                entity.ToTable("Factors");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Rating).HasColumnType("money");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.ToTable("Occupations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            });

            modelBuilder.Seed();


            
        }
        
    }
}
