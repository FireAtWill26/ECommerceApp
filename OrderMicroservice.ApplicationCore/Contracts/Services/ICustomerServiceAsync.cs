using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Entities.Customer;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface ICustomerServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<CustomerResponseModel>> GetAll();

        Task<CustomerResponseModel> GetById(int id);

        Task<int> Insert(CustomerRequestModel model);

        Task<int> Update(CustomerRequestModel model, int id);

        Task<IEnumerable<AddressResponseModel>> GetCustomerAddressByUserId(string userId);

        Task<int> SaveCustomerAddress(int customerId, AddressRequestModel model);
    }
}
