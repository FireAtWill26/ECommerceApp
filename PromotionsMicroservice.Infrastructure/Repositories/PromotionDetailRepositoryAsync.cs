using PromotionsMicroservice.ApplicationCore.Contracts.Repositories;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Repositories
{
    public class PromotionDetailRepositoryAsync : BaseRepositoryAsync<Promotion_Detail>, IPromotionDetailRepositoryAsync
    {
        public PromotionDetailRepositoryAsync(ECommerceDbContext context) : base(context)
        {
        }
    }
}
