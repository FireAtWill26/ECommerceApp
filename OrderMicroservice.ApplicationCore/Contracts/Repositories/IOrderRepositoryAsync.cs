using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.ApplicationCore.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IOrderRepositoryAsync: IRepositoryAsync<Order>
    {
        Task<IEnumerable<Order>> GetOrderByCustomerId(int customerId);
    }
}
