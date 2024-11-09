
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
    public class ShippingDetailServiceAsync : IShippingDetailServiceAsync
    {
        private readonly IShippingDetailRepositoryAsync _repo;
        private readonly IMapper mapper;

        public ShippingDetailServiceAsync(IShippingDetailRepositoryAsync shippingDetailRepositoryAsync, IMapper mapper)
        {
            _repo = shippingDetailRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ShippingDetailResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<ShippingDetailResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<ShippingDetailResponseModel> GetById(int id)
        {
            return mapper.Map<ShippingDetailResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(ShippingDetailRequestModel model)
        {
            var result = mapper.Map<ShippingDetail>(model);
            return await _repo.InsertAsync(result);
        }

        public async Task<int> Update(ShippingDetailRequestModel model, int id)
        {
            if (id == model.Id)
            {
                var result = mapper.Map<ShippingDetail>(model);
                return await _repo.UpdateAsync(result);
            }
            return 0;
        }
    }
}