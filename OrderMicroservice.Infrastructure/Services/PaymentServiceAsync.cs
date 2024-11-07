using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.ApplicationCore.Entities.ShopingCart;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;
using OrderMicroservice.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class PaymentServiceAsync : IPaymentServiceAsync
    {
        private readonly IPaymentRepositoryAsync paymentRepositoryAsync;
        private readonly IMapper mapper;

        public PaymentServiceAsync(IPaymentRepositoryAsync paymentRepositoryAsync, IMapper mapper)
        {
            this.paymentRepositoryAsync = paymentRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await paymentRepositoryAsync.DeleteAsync(id);
        }


        public async Task<IEnumerable<PaymentMethodResponseModel>> GetByCustomerId(int id)
        {
            return mapper.Map<IEnumerable<PaymentMethodResponseModel>>((await paymentRepositoryAsync.GetAllAsync())
                .Where(x => x.CustomerId == id));
        }

        public async Task<int> Insert(PaymentMethodRequestModel model)
        {
            var result = mapper.Map<PaymentMethod>(model);
            return await paymentRepositoryAsync.InsertAsync(result);
        }

        public async Task<int> Update(PaymentMethodRequestModel model, int id)
        {
            if (id == model.Id)
            {
                var result = mapper.Map<PaymentMethod>(model);
                return await paymentRepositoryAsync.UpdateAsync(result);
            }
            return 0;
        }
    }
}
