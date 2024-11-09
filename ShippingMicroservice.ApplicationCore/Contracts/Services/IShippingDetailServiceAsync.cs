using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Contracts.Services
{
    public interface IShippingDetailServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<ShippingDetailResponseModel>> GetAll();

        Task<ShippingDetailResponseModel> GetById(int id);

        Task<int> Insert(ShippingDetailRequestModel model);

        Task<int> Update(ShippingDetailRequestModel model, int id);

    }
}
