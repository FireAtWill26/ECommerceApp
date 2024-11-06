using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class OrderDetailRepositoryAsync : BaseRepositoryAsync<Order_Detail>, IOrderDetailRepositoryAsync
    {
        public OrderDetailRepositoryAsync(ECommerceDbContext context) : base(context)
        {
        }
    }
}
