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

    public class ProductVariationServiceAsync : IProductVariationServiceAsync
    {
        private readonly IProductVariationRepositoryAsync _repo;
        private readonly IMapper mapper;

        public ProductVariationServiceAsync(IProductVariationRepositoryAsync ProductVariationRepositoryAsync, IMapper mapper)
        {
            _repo = ProductVariationRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductVariationResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<ProductVariationResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<ProductVariationResponseModel> GetById(int id)
        {
            return mapper.Map<ProductVariationResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(ProductVariationRequestModel model)
        {
            var result = mapper.Map<ProductVariation>(model);
            return await _repo.InsertAsync(result);
        }
    }
}
