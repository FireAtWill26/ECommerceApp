
using ReviewMicroservice.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewMicroservice.ApplicationCore.Contracts.Repositories
{
    public interface IReviewRepositoryAsync : IRepositoryAsync<CustomerReview>
    {
        Task<IEnumerable<CustomerReview>> GetByCustomer(int userId);

        Task<IEnumerable<CustomerReview>> GetByProduct(int productId);

        Task<IEnumerable<CustomerReview>> GetByYear(int year);
    }
}
