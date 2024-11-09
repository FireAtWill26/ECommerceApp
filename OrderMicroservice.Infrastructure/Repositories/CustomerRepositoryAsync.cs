using Microsoft.EntityFrameworkCore;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Entities.Customer;
using OrderMicroservice.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.Infrastructure.Repositories
{
    public class CustomerRepositoryAsync : BaseRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly ECommerceDbContext context;

        public CustomerRepositoryAsync(ECommerceDbContext context) : base(context) 
        {
            this.context = context;
        }

        public async Task<IEnumerable<Address>> GetAddressByUserId(string userId)
        {
            Customer? customer = await context.Set<Customer>().Include(x => x.UserAddresses).
                ThenInclude(x => x.Address).FirstOrDefaultAsync(x=>x.UserId == userId);
            var result = new List<Address>();
            if (customer != null)
            {
                foreach(UserAddress userAddress in customer.UserAddresses)
                {
                    result.Add(userAddress.Address);
                }
            }
            return result;
        }

        public async Task<int> SaveCustomerAddress(int customerId, Address address)
        {
            UserAddress userAddress = new UserAddress 
            {
                Customer_Id = customerId,
                Address_Id = (await context.Address.MaxAsync(x => x.Id)) + 1,
                IsDefaultAddress = false
            };
            await context.Set<Address>().AddAsync(address);
            await context.Set<UserAddress>().AddAsync(userAddress);
            return await context.SaveChangesAsync();
        }
    }
}
