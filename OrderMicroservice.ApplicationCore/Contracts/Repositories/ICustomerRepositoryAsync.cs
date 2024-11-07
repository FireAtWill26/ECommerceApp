using OrderMicroservice.ApplicationCore.Entities.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface ICustomerRepositoryAsync : IRepositoryAsync<Customer>
    {
        Task<int> SaveCustomerAddress(int customerId, Address address);

        Task<IEnumerable<Address>> GetAddressByUserId(string userId);
    }
}
