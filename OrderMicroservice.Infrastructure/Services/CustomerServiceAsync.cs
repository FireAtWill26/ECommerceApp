using AutoMapper;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.ApplicationCore.Entities.Customer;
using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Services
{
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        private readonly IMapper mapper;

        public CustomerServiceAsync(ICustomerRepositoryAsync customerRepositoryAsync, IMapper mapper)
        {
            this.customerRepositoryAsync = customerRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await customerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<CustomerResponseModel>>(await customerRepositoryAsync.GetAllAsync());
        }

        public async Task<CustomerResponseModel> GetById(int id)
        {
            return mapper.Map<CustomerResponseModel>(await customerRepositoryAsync.GetByIdAsync(id));
        }

        public async Task<int> Insert(CustomerRequestModel model)
        {
            var result = mapper.Map<Customer>(model);
            return await customerRepositoryAsync.InsertAsync(result);
        }

        public async Task<int> Update(CustomerRequestModel model, int id)
        {
            if (id == model.Id)
            {
                var result = mapper.Map<Customer>(model);
                return await customerRepositoryAsync.UpdateAsync(result);
            }
            return 0;
        }

        public async Task<IEnumerable<AddressResponseModel>> GetCustomerAddressByUserId(string userId)
        {
            return mapper.Map<IEnumerable<AddressResponseModel>>(await customerRepositoryAsync.GetAddressByUserId(userId));
        }

        public async Task<int> SaveCustomerAddress(int customerId, AddressRequestModel model)
        {
            Address address = mapper.Map<Address>(model);
            return await customerRepositoryAsync.SaveCustomerAddress(customerId, address);
        }
    }
}
