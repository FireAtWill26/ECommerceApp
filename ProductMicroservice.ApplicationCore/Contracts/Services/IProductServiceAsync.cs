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
    public interface IProductServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<ProductResponseModel>> GetAll();

        Task<ProductResponseModel> GetById(int id);

        Task<int> Insert(ProductRequestModel model);

        Task<int> Update(ProductRequestModel model, int id);

        Task<IEnumerable<ProductResponseModel>> GetByCategoryId(int id);

        Task<IEnumerable<ProductResponseModel>> GetByName(string name);
    }
}
