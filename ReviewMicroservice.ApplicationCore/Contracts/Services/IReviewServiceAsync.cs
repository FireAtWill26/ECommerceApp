using ReviewMicroservice.ApplicationCore.Entities;
using ReviewMicroservice.ApplicationCore.Models.Request;
using ReviewMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicationCore.Contracts.Services
{
    public interface IReviewServiceAsync
    {
        Task<int> Insert(CustomerReviewRequestModel entity);
        Task<int> Update(CustomerReviewRequestModel entity, int id);
        Task<int> Delete(int id);

        Task<CustomerReviewResponseModel> GetById(int id);

        Task<IEnumerable<CustomerReviewResponseModel>> GetAll();

        Task<IEnumerable<CustomerReviewResponseModel>> GetByCustomer(int userId);

        Task<IEnumerable<CustomerReviewResponseModel>> GetByProduct(int productId);

        Task<IEnumerable<CustomerReviewResponseModel>> GetByYear(int year);
    }
}
