using AutoMapper;
using ReviewMicroservice.ApplicationCore.Entities;
using ReviewMicroservice.ApplicationCore.Models.Request;
using ReviewMicroservice.ApplicationCore.Models.Response;

namespace ReviewMicroservice.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<CustomerReview, CustomerReviewRequestModel>().ReverseMap();
            CreateMap<CustomerReview, CustomerReviewResponseModel>().ReverseMap();
        }
    }
}
