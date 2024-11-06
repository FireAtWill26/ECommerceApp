
using AutoMapper;
using PromotionsMicroservice.ApplicationCore.Contracts.Repositories;
using PromotionsMicroservice.ApplicationCore.Contracts.Services;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.ApplicationCore.Models.Request;
using PromotionsMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.Infrastructure.Services
{
    public class PromotionServiceAsync : IPromotionServiceAsync
    {
        private readonly IPromotionRepositoryAsync _repo;
        private readonly IMapper mapper;

        public PromotionServiceAsync(IPromotionRepositoryAsync repo, IMapper mapper)
        {
            _repo = repo;
            this.mapper = mapper;
        }
        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetAllAsync()
        {
            return mapper.Map<IEnumerable<PromotionResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<PromotionResponseModel> GetById(int id)
        {
            return mapper.Map<PromotionResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(PromotionRequestModel model)
        {
            var result = mapper.Map<Promotion>(model);
            return await _repo.InsertAsync(result);
        }

        public async Task<int> Update(PromotionRequestModel model, int id)
        {
            if (id == model.id)
            {
                var result = mapper.Map<Promotion>(model);
                return await _repo.UpdateAsync(result);
            }
            return 0;
        }

        public async Task<PromotionResponseModel> GetByName(string name)
        {
            return mapper.Map<PromotionResponseModel>(await _repo.GetByName(name));
        }

        public async Task<IEnumerable<PromotionResponseModel>> GetActive()
        {
            return mapper.Map<IEnumerable<PromotionResponseModel>>(await _repo.GetActive());
        }

    }
}
