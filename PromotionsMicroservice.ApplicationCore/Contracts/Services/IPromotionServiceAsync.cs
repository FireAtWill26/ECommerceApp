
using Azure.Core;
using Azure;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.ApplicationCore.Models.Request;
using PromotionsMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionsMicroservice.ApplicationCore.Contracts.Services
{
    public interface IPromotionServiceAsync
    {
        Task<int> Delete(int id);
        Task<IEnumerable<PromotionResponseModel>> GetAllAsync();
        Task<PromotionResponseModel> GetById(int id);
        Task<int> Insert(PromotionRequestModel model);
        Task<int> Update(PromotionRequestModel model, int id);
        Task<PromotionResponseModel> GetByName(string name);
        Task<IEnumerable<PromotionResponseModel>> GetActive();
    }
}
