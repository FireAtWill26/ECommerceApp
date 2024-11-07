using AutoMapper;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductMicroservice.ApplicationCore.Contracts.Services
{
    public interface ICategoryVariationServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<CategoryVariationResponseModel>> GetAll();

        Task<CategoryVariationResponseModel> GetById(int id);

        Task<int> Insert(CategoryVariationRequestModel model);

        Task<IEnumerable<CategoryVariationResponseModel>> GetByCategoryId(int id);
    }
}
