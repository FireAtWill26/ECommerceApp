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
    public interface IVariationValueServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<VariationValueResponseModel>> GetAll();

        Task<VariationValueResponseModel> GetById(int id);

        Task<int> Insert(VariationValueRequestModel model);

        Task<int> Update(VariationValueRequestModel model, int id);
    }
}
