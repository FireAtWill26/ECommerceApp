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

    public class CategoryVariationServiceAsync : ICategoryVariationServiceAsync
    {
        private readonly ICategoryVariationRepositoryAsync _repo;
        private readonly IMapper mapper;

        public CategoryVariationServiceAsync(ICategoryVariationRepositoryAsync CategoryVariationRepositoryAsync, IMapper mapper)
        {
            _repo = CategoryVariationRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryVariationResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<CategoryVariationResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<CategoryVariationResponseModel> GetById(int id)
        {
            return mapper.Map<CategoryVariationResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(CategoryVariationRequestModel model)
        {
            var result = mapper.Map<CategoryVariation>(model);
            return await _repo.InsertAsync(result);
        }

        public async Task<IEnumerable<CategoryVariationResponseModel>> GetByCategoryId(int id)
        {
            return mapper.Map<IEnumerable<CategoryVariationResponseModel>>((await _repo.GetAllAsync())
                .Where(x => x.Category_Id == id));
        }
    }
}
