using Microsoft.EntityFrameworkCore;
using ReviewMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.Infrastructure.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> option): base(option)
        {
            
        }

        DbSet<CustomerReview> Customer_Review {  get; set; }
    }
}
