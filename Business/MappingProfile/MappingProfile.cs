using AutoMapper;
using Core.Entities.Concrete;
using Entities.Dtos;

namespace Business.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDetailDto>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
        }
    }
}