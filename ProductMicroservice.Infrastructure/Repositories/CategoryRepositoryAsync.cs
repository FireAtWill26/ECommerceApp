using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryRepositoryAsync : BaseRepositoryAsync<Category>
    {
        public CategoryRepositoryAsync(ECommerceDbContext context) : base(context)
        {
        }
    }
}
