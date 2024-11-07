using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMicroservice.ApplicationCore.Contracts.Services
{
    public interface IShoppingCartItemServiceAsync
    {
        Task<int> Delete(int id);
    }
}
