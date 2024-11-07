using AutoMapper;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
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
    public interface ICategoryServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<CategoryResponseModel>> GetAll();

        Task<CategoryResponseModel> GetById(int id);

        Task<int> Insert(CategoryRequestModel model);

        Task<IEnumerable<CategoryResponseModel>> GetByParentId(int id);
    }
}
