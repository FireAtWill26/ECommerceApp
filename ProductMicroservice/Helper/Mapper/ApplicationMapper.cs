using AutoMapper;
using ProductMicroservice.ApplicationCore.Entities;
using ProductMicroservice.ApplicationCore.Models.Request;
using ProductMicroservice.ApplicationCore.Models.Response;

namespace ProductMicroservice.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Category, CategoryRequestModel>().ReverseMap();
            CreateMap<Category, CategoryResponseModel>().ReverseMap();

            CreateMap<Product, ProductRequestModel>().ReverseMap();
            CreateMap<Product, ProductResponseModel>().ReverseMap();

            CreateMap<CategoryVariation, CategoryVariationRequestModel>().ReverseMap();
            CreateMap<CategoryVariation, CategoryVariationResponseModel>().ReverseMap();

            CreateMap<ProductVariation, ProductVariationRequestModel>().ReverseMap();
            CreateMap<ProductVariation, ProductVariationResponseModel>().ReverseMap();

            CreateMap<VariationValue, VariationValueRequestModel>().ReverseMap();
            CreateMap<VariationValue, VariationValueResponseModel>().ReverseMap();
        }
    }
}
