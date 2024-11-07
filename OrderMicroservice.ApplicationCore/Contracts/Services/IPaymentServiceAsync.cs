using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Entities.ShopingCart;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface IPaymentServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<PaymentMethodResponseModel>> GetByCustomerId(int id);

        Task<int> Insert(PaymentMethodRequestModel model);

        Task<int> Update(PaymentMethodRequestModel model, int id);
    }
}
