using AutoMapper;
using HMS_API.Models;
using HMS_API.Models.Dto;

namespace HMS_API
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<UserDTO, SignInRequestDto>().ReverseMap();
            CreateMap<User, SignUpRequestDto>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
