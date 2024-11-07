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
    public class CategoryServiceAsync : ICategoryServiceAsync
    {
        private readonly ICategoryRepositoryAsync _repo;
        private readonly IMapper mapper;

        public CategoryServiceAsync(ICategoryRepositoryAsync categoryRepositoryAsync, IMapper mapper)
        {
            _repo = categoryRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<CategoryResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<CategoryResponseModel> GetById(int id)
        {
            return mapper.Map<CategoryResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(CategoryRequestModel model)
        {
            var result = mapper.Map<Category>(model);
            return await _repo.InsertAsync(result);
        }

        public async Task<IEnumerable<CategoryResponseModel>> GetByParentId(int id)
        {
            return mapper.Map<IEnumerable<CategoryResponseModel>>((await _repo.GetAllAsync()).
                Where(x => x.Parent_Category_Id == id));
        }
    }
}
