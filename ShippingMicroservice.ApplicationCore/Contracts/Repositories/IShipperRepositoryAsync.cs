﻿
using ShippingMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IShipperRepositoryAsync : IRepositoryAsync<Shipper>
    {
        Task<IEnumerable<Shipper>> GetByRegion(int regionId);
    }
}
