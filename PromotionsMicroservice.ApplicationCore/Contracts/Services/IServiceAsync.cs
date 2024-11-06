
using PromotionsMicroservice.ApplicationCore.Contracts.Repositories;
using PromotionsMicroservice.ApplicationCore.Models.Request;
using PromotionsMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Contracts.Services
{
    public interface IServiceAsync<TClass, TRequest, TResponse> 
        where TRequest : class where TResponse : class where TClass : class
    {
        Task<int> Delete(int id);
        Task<IEnumerable<TResponse>> GetAllAsync();
        Task<TResponse> GetById(int id);
        Task<int> Insert(TRequest model);
        Task<int> Update(TRequest model, int id);
    }
}
