using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Entities.ShopingCart;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class ShoppingCartServiceAsync : IShoppingCartServiceAsync
    {
        private readonly IShoppingCartRepositoryAsync shoppingCartRepositoryAsync;
        private readonly IMapper mapper;

        public ShoppingCartServiceAsync(IShoppingCartRepositoryAsync shoppingCartRepositoryAsync, IMapper mapper)
        {
            this.shoppingCartRepositoryAsync = shoppingCartRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await shoppingCartRepositoryAsync.DeleteAsync(id);
        }


        public async Task<IEnumerable<ShoppingCartResponseModel>> GetByCustomerId(int id)
        {
            return mapper.Map<IEnumerable<ShoppingCartResponseModel>>((await shoppingCartRepositoryAsync.GetAllAsync())
                .Where(x => x.CustomerId == id));
        }

        public async Task<int> Insert(ShoppingCartRequestModel model)
        {
            var result = mapper.Map<ShoppingCart>(model);
            return await shoppingCartRepositoryAsync.InsertAsync(result);
        }
    }
}
