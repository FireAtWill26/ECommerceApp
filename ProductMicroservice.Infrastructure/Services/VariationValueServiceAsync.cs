using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.Infrastructure.Services
{

    public class VariationValueServiceAsync : IVariationValueServiceAsync
    {
        private readonly IVariationValueRepositoryAsync _repo;
        private readonly IMapper mapper;

        public VariationValueServiceAsync(IVariationValueRepositoryAsync VariationValueRepositoryAsync, IMapper mapper)
        {
            _repo = VariationValueRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<VariationValueResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<VariationValueResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<VariationValueResponseModel> GetById(int id)
        {
            return mapper.Map<VariationValueResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(VariationValueRequestModel model)
        {
            var result = mapper.Map<VariationValue>(model);
            return await _repo.InsertAsync(result);
        }

        public async Task<int> Update(VariationValueRequestModel model, int id)
        {
            if (id == model.Id)
            {
                var result = mapper.Map<VariationValue>(model);
                return await _repo.UpdateAsync(result);
            }
            return 0;
        }
    }
}
