using AutoMapper;
using Chat.Application.Models;
using Chat.Domain.Entities;

namespace Chat.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Message, MessageDTO>();
        }
    }
}
