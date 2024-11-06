using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Data
{
    public class ECommerceDbContext: DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Promotion_Detail>()
                .HasOne(pd => pd.Promotion)
                .WithMany(p => p.Details)
                .HasForeignKey(pd => pd.Promotion_Id);
        }

        public DbSet<Promotion> Promotions { get; set; }

        public DbSet<Promotion_Detail> Promotion_Details { get; set; }
    }
}
