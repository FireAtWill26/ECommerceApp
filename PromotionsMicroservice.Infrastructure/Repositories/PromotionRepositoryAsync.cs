
using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Contracts.Repositories;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.ApplicationCore.Models.Response;
using PromotionsMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Repositories
{
    public class PromotionRepositoryAsync : BaseRepositoryAsync<Promotion>, IPromotionRepositoryAsync
    {
        private readonly ECommerceDbContext context;
        public PromotionRepositoryAsync(ECommerceDbContext context) : base(context)
        {
            this.context = context;
        }


        public async Task<Promotion> GetByName(string name)
        {
            return await context.Set<Promotion>().FirstOrDefaultAsync(x => x.name == name);
        }

        public async Task<IEnumerable<Promotion>> GetActive()
        {
            return await context.Set<Promotion>().Where(x => x.startDate <= DateTime.Today)
                .Where(x => x.endDate >= DateTime.Today).ToListAsync();
        }
    }
}
