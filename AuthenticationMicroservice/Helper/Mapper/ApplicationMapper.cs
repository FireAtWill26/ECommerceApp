using AuthenticationMicroservice.Model;
using AutoMapper;

namespace AuthenticationMicroservice.Helper.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<UpdateUser, ApplicationUser>();
        }
    }
}
