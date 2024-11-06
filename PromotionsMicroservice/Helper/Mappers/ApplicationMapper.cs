using AutoMapper;
using PromotionsMicroservice.ApplicationCore.Entities;
using PromotionsMicroservice.ApplicationCore.Models.Request;
using PromotionsMicroservice.ApplicationCore.Models.Response;

namespace PromotionsMicroservice.Helper.Mappers
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Promotion, PromotionRequestModel>().ReverseMap();
            CreateMap<Promotion, PromotionResponseModel>().ReverseMap();
        }
    }
}
