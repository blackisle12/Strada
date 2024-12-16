using AutoMapper;
using Strada.Models.User;
using Strada.Repository.Models;

namespace Strada.Service.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUserResponse>();
            CreateMap<Address, GetUserAddressResponse>();
            CreateMap<Employment, GetUserEmploymentResponse>();

            CreateMap<CreateUserRequest, User>();
            CreateMap<CreateUserAddressRequest, Address>();
            CreateMap<CreateUserEmploymentRequest, Employment>();

            CreateMap<UpdateUserRequest, User>();
            CreateMap<UpdateUserAddressRequest, Address>();
            CreateMap<UpdateUserEmploymentRequest, Employment>();
        }
    }
}
