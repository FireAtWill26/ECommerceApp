using AutoMapper;
using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;

namespace OrderAPI.Helper.Mapper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Order, OrderRequestModel>().ReverseMap();
            CreateMap<Order, OrderResponseModel>().ReverseMap();
        }
    }
}
