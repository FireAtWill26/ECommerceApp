using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class ShoppingCartItemServiceAsync : IShoppingCartItemServiceAsync
    {
        private readonly IShoppingCartItemRepositoryAsync ShoppingCartItemRepositoryAsync;

        public ShoppingCartItemServiceAsync(IShoppingCartItemRepositoryAsync shoppingCartItemRepositoryAsync, IMapper mapper)
        {
            this.ShoppingCartItemRepositoryAsync = shoppingCartItemRepositoryAsync;
        }

        public async Task<int> Delete(int id)
        {
            return await ShoppingCartItemRepositoryAsync.DeleteAsync(id);
        }
    }
}
