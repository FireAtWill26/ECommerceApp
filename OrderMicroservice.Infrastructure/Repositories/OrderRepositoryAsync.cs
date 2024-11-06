using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.ApplicationCore.Model.Response;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class OrderRepositoryAsync : BaseRepositoryAsync<Order>, IOrderRepositoryAsync
    {
        private ECommerceDbContext _context;
        public OrderRepositoryAsync(ECommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetOrderByCustomerId(int customerId)
        {
            return await _context.Order.Where(x => x.CustomerId == customerId).ToListAsync();
        }
    }
}
