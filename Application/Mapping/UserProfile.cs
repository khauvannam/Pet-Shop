using Application.Commands.Accounts;
using AutoMapper;
using Domain.Entities.Users;

namespace Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterViewModel, Register.Command>().ReverseMap();
        CreateMap<RegisterViewModel, User>();
    }
}
