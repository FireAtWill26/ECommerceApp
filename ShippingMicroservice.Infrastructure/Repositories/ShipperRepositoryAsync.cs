using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Contracts.Repositories;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Repositories
{
    public class ShipperRepositoryAsync : BaseRepositoryAsync<Shipper>, IShipperRepositoryAsync
    {
        private readonly ECommerceDbContext _context;

        public ShipperRepositoryAsync(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Shipper>> GetByRegion(int regionId)
        {
            return await _context.Set<Shipper>()
                .Where(x => x.Shipper_Regions.Any(x => x.Region_Id == regionId)).ToListAsync();
        }
    }
}
