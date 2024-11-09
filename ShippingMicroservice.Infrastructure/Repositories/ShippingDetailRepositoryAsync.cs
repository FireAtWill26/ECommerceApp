﻿using ShippingMicroservice.ApplicationCore.Contracts.Repositories;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class ShippingDetailRepositoryAsync : BaseRepositoryAsync<ShippingDetail>, IShippingDetailRepositoryAsync
    {
        public ShippingDetailRepositoryAsync(ECommerceDbContext context) : base(context)
        {
        }
    }
}
