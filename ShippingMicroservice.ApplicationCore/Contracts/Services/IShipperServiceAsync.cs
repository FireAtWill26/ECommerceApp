using AutoMapper;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.ApplicationCore.Contracts.Services
{
    public interface IShipperServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<ShipperResponseModel>> GetAll();

        Task<ShipperResponseModel> GetById(int id);

        Task<int> Insert(ShipperRequestModel model);

        Task<int> Update(ShipperRequestModel model, int id);

        Task<IEnumerable<ShipperResponseModel>> GetByRegion(int regionId);
    }
}
