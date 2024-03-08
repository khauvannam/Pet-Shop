using Application.AccountHandler;
using Application.AccountHandler.Commands;
using AutoMapper;
using Domain.Entity.Users;

namespace Application.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterViewModel, Register.Command>().ReverseMap();
        CreateMap<RegisterViewModel, User>();
    }
}
