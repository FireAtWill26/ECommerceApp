using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Entities.Customer;
using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.ApplicationCore.Entities.ShopingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Data
{
    public class ECommerceDbContext: DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> context): base(context)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Customer)
                .WithMany(c => c.UserAddresses)
                .HasForeignKey(ua => ua.Customer_Id);


            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Address)
                .WithMany(a => a.UserAddresses)
                .HasForeignKey(ua => ua.Address_Id);


            modelBuilder.Entity<UserAddress>().ToTable("User_Address");
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<Order_Detail> Order_Details { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<ShoppingCart> Shopping_Cart { get; set; }
        public DbSet<ShoppingCartItem> Shopping_Cart_Item { get; set; }
        public DbSet<PaymentType> Payment_Type { get; set; }
        public DbSet<PaymentMethod> Payment_Method { get; set; }

    }
}
