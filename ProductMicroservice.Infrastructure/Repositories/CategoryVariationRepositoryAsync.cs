﻿using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class CategoryVariationRepositoryAsync : BaseRepositoryAsync<CategoryVariation>
    {
        public CategoryVariationRepositoryAsync(ECommerceDbContext context) : base(context)
        {
        }
    }
}