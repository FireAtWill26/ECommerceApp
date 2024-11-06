
using Microsoft.EntityFrameworkCore;
using ReviewMicroservice.ApplicationCore.Contracts.Repositories;
using ReviewMicroservice.ApplicationCore.Entities;
using ReviewMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.Infrastructure.Repositories
{
    public class ReviewRepositoryAsync : BaseRepositoryAsync<CustomerReview>, IReviewRepositoryAsync
    {

        private readonly ECommerceDbContext context;

        public ReviewRepositoryAsync(ECommerceDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CustomerReview>> GetByCustomer(int userId)
        {
            return await context.Set<CustomerReview>().Where(x => x.customerId == userId).ToListAsync();
        }

        public async Task<IEnumerable<CustomerReview>> GetByProduct(int productId)
        {
            return await context.Set<CustomerReview>().Where(x => x.productId == productId).ToListAsync();
        }

        public async Task<IEnumerable<CustomerReview>> GetByYear(int year)
        {
            return await context.Set<CustomerReview>().Where(x => x.reviewDate.Year == year).ToListAsync();
        }
    }
}
