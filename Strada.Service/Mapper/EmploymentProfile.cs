using AutoMapper;
using Strada.Models.Employment;
using Strada.Models.User;
using Strada.Repository.Models;

namespace Strada.Service.Mapper
{
    public class EmploymentProfile : Profile
    {
        public EmploymentProfile()
        {
            CreateMap<CreateEmploymentRequest, Employment>();
            CreateMap<UpdateEmploymentRequest, Employment>();

            CreateMap<CreateEmploymentRequest, EmploymentDateRange>();
            CreateMap<UpdateEmploymentRequest, EmploymentDateRange>();
            CreateMap<CreateUserEmploymentRequest, EmploymentDateRange>();
            CreateMap<UpdateUserEmploymentRequest, EmploymentDateRange>();
        }
    }
}
