using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> option) : base(option)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Shipper_Region>().HasKey(x => new { x.Region_Id, x.Shipper_Id });

            modelBuilder.Entity<Shipper_Region>()
                .HasOne(sr => sr.Region)
                .WithMany(r => r.Shipper_Regions)
                .HasForeignKey(sr => sr.Region_Id);

            modelBuilder.Entity<Shipper_Region>()
                .HasOne(sr => sr.Shipper)
                .WithMany(s => s.Shipper_Regions)
                .HasForeignKey(sr => sr.Shipper_Id);
        }

        public DbSet<Shipper> Shipper { get; set; }

        public DbSet<Region> Region { get; set; }

        public DbSet<ShippingDetail> Shipping_Details { get; set; }
    }
}
