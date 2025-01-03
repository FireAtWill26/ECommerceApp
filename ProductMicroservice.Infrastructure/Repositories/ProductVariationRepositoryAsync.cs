﻿
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Repositories
{
    public class ProductVariationRepositoryAsync : BaseRepositoryAsync<ProductVariation>, IProductVariationRepositoryAsync
    {
        public ProductVariationRepositoryAsync(ECommerceDbContext context) : base(context)
        {
        }
    }
}
