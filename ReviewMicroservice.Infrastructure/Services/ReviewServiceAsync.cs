using AutoMapper;
using ReviewMicroservice.ApplicationCore.Contracts.Repositories;
using ReviewMicroservice.ApplicationCore.Contracts.Services;
using ReviewMicroservice.ApplicationCore.Entities;
using ReviewMicroservice.ApplicationCore.Models.Request;
using ReviewMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.Infrastructure.Services
{
    public class ReviewServiceAsync : IReviewServiceAsync
    {
        private readonly IReviewRepositoryAsync _repo;
        private readonly IMapper mapper;

        public ReviewServiceAsync(IReviewRepositoryAsync reviewRepositoryAsync, IMapper mapper)
        {
            _repo = reviewRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<int> Delete(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerReviewResponseModel>> GetAll()
        {
            return mapper.Map<IEnumerable<CustomerReviewResponseModel>>(await _repo.GetAllAsync());
        }

        public async Task<CustomerReviewResponseModel> GetById(int id)
        {
            return mapper.Map<CustomerReviewResponseModel>(await _repo.GetByIdAsync(id));
        }

        public async Task<int> Insert(CustomerReviewRequestModel model)
        {
            var result = mapper.Map<CustomerReview>(model);
            return await _repo.InsertAsync(result);
        }

        public async Task<int> Update(CustomerReviewRequestModel model, int id)
        {
            if (id == model.id)
            {
                var result = mapper.Map<CustomerReview>(model);
                return await _repo.UpdateAsync(result);
            }
            return 0;
        }

        public async Task<IEnumerable<CustomerReviewResponseModel>> GetByCustomer(int userId)
        {
            return mapper.Map<IEnumerable<CustomerReviewResponseModel>>(await _repo.GetByCustomer(userId));
        }

        public async Task<IEnumerable<CustomerReviewResponseModel>> GetByProduct(int productId)
        {
            return mapper.Map<IEnumerable<CustomerReviewResponseModel>>(await _repo.GetByProduct(productId));
        }

        public async Task<IEnumerable<CustomerReviewResponseModel>> GetByYear(int year)
        {
            return mapper.Map<IEnumerable<CustomerReviewResponseModel>>(await _repo.GetByYear(year));
        }
    }
}
