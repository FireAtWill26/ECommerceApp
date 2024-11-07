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
    public class ShoppingCartRepositoryAsync : BaseRepositoryAsync<ShoppingCart>, IShoppingCartRepositoryAsync
    {
        public ShoppingCartRepositoryAsync(ECommerceDbContext context) : base(context)
        {
        }
    }
}
