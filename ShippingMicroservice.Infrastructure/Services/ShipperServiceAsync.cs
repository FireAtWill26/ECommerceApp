using AutoMapper;
using ShippingMicroservice.ApplicationCore.Contracts.Repositories;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.ApplicationCore.Entities;
using ShippingMicroservice.ApplicationCore.Models.Request;
using ShippingMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingMicroservice.Infrastructure.Services
{
    public class ShipperServiceAsync : IShipperServiceAsync
    {
        private readonly IShipperRepositoryAsync _repo;
        private readonly IMapper mapper;

        public ShipperServiceAsync(IShipperRepositoryAsync shipperRepositoryAsync, IMapper mapper)
        {
            _repo = shipperRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<ShipperResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<ShipperResponseModel> GetById(int id)
        {
            return mapper.Map<ShipperResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(ShipperRequestModel model)
        {
            var result = mapper.Map<Shipper>(model);
            return await _repo.InsertAsync(result);
        }

        public async Task<int> Update(ShipperRequestModel model, int id)
        {
            if (id == model.id)
            {
                var result = mapper.Map<Shipper>(model);
                return await _repo.UpdateAsync(result);
            }
            return 0;
        }

        public async Task<IEnumerable<ShipperResponseModel>> GetByRegion(int regionId)
        {
            return mapper.Map<IEnumerable<ShipperResponseModel>>(await _repo.GetByRegion(regionId));
        }
    }
}
