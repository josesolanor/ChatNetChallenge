using AutoMapper;
using Chat.Application.Models;
using Chat.Domain.Entities;

namespace Chat.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<LoginDTO, User>();
            CreateMap<MessageDTO, Message>();
        }
    }
}
