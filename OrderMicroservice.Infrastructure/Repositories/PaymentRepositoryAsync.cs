using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Entities.ShopingCart;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class PaymentRepositoryAsync : BaseRepositoryAsync<PaymentMethod>, IPaymentRepositoryAsync
    {
        public PaymentRepositoryAsync(ECommerceDbContext context) : base(context)
        {
        }
    }
}
