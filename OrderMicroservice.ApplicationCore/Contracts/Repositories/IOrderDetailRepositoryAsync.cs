using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IOrderDetailRepositoryAsync: IRepositoryAsync<Order_Detail>
    {
    }
}
