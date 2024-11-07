using AutoMapper;
using OrderMicroservice.ApplicationCore.Entities.Customer;
using OrderMicroservice.ApplicationCore.Entities.OrderHistory;
using OrderMicroservice.ApplicationCore.Entities.ShopingCart;
using OrderMicroservice.ApplicationCore.Model.Request;
using OrderMicroservice.ApplicationCore.Model.Response;

namespace OrderMicroservice.Helper.Mapper
{
    public class ApplicationMapper: Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<Order, OrderRequestModel>().ReverseMap();
            CreateMap<Order, OrderResponseModel>().ReverseMap();

            CreateMap<Customer, CustomerRequestModel>().ReverseMap();
            CreateMap<Customer, CustomerResponseModel>().ReverseMap();

            CreateMap<PaymentMethod, PaymentMethodRequestModel>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodResponseModel>().ReverseMap();

            CreateMap<ShoppingCart, ShoppingCartRequestModel>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartResponseModel>().ReverseMap();

            CreateMap<ShoppingCartItem, ShoppingCartItemRequestModel>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemResponseModel>().ReverseMap();

            CreateMap<Address, AddressRequestModel>().ReverseMap();
            CreateMap<Address, AddressResponseModel>().ReverseMap();
        }
    }
}
