using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Data
{
    public class ECommerceDbContext: DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> option) : base(option)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProductVariation>().HasKey(x => new { x.Product_Id, x.Variation_value_Id });

            modelBuilder.Entity<ProductVariation>()
                .HasOne(pv => pv.Product)
                .WithMany(p => p.ProductVariations)
                .HasForeignKey(pv => pv.Product_Id);

            modelBuilder.Entity<ProductVariation>()
                .HasOne(pv => pv.Variation)
                .WithMany(v => v.ProductVariations)
                .HasForeignKey(pv => pv.Variation_value_Id);

            modelBuilder.Entity<CategoryVariation>()
                .HasOne(cv => cv.Category)
                .WithMany(c => c.Variations)
                .HasForeignKey(cv => cv.Category_Id);

            modelBuilder.Entity<VariationValue>()
                .HasOne(vv => vv.Variation)
                .WithMany(v => v.Values)
                .HasForeignKey(vv => vv.variation_Id).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProductVariation>().ToTable("Product_variation_values");

            modelBuilder.Entity<Category>()
                .HasOne(c => c.Parent)
                .WithMany(p => p.SubCategories)
                .HasForeignKey(p => p.Parent_Category_Id)
                .OnDelete(DeleteBehavior.Restrict).IsRequired(false);
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Product_Category { get; set; }

        public DbSet<CategoryVariation> Category_Variation { get; set; }

        public DbSet<VariationValue> Variation_Value { get; set; }

        public DbSet<ProductVariation> Product_variation_values { get; set; }

    }
}
