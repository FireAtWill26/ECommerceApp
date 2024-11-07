﻿using AutoMapper;
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
    public interface IProductVariationServiceAsync
    {
        Task<int> Delete(int id);

        Task<IEnumerable<ProductVariationResponseModel>> GetAll();

        Task<ProductVariationResponseModel> GetById(int id);

        Task<int> Insert(ProductVariationRequestModel model);
    }
}
