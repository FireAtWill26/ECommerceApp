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

    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync _repo;
        private readonly IMapper mapper;

        public ProductServiceAsync(IProductRepositoryAsync ProductRepositoryAsync, IMapper mapper)
        {
            _repo = ProductRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<ProductResponseModel> GetById(int id)
        {
            return mapper.Map<ProductResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(ProductRequestModel model)
        {
            var result = mapper.Map<Product>(model);
            return await _repo.InsertAsync(result);
        }

        public async Task<int> Update(ProductRequestModel model, int id)
        {
            if (id == model.Id)
            {
                var result = mapper.Map<Product>(model);
                return await _repo.UpdateAsync(result);
            }
            return 0;
        }

        public async Task<IEnumerable<ProductResponseModel>> GetByCategoryId(int id)
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>((await _repo.GetAllAsync())
                .Where(x => x.CategoryId == id));
        }

        public async Task<IEnumerable<ProductResponseModel>> GetByName(string name)
        {
            return mapper.Map<IEnumerable<ProductResponseModel>>((await _repo.GetAllAsync())
                .Where(x => x.Name == name));
        }

    }
}
