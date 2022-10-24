using AutoMapper;
using Pacagroup.Ecommerce.Aplication.Dto;
using Pacagroup.Ecommerce.Domain.Entity;
namespace Pacagroup.Ecommerce.Transversal.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomersDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}