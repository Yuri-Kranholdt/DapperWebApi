using AutoMapper;
using DapperWebApi.Dto;
using DapperWebApi.Models;

namespace DapperWebApi.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<User, UserlistDto>(); // user to userlistdto
        }
    }
}
