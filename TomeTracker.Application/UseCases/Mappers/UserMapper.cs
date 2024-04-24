using AutoMapper;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.User.Commands;
using TomeTracker.Domain.Entities;

namespace TomeTracker.Application.UseCases.Mappers;

public class UserMapper: Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserRequest, Domain.Entities.User>();
        CreateMap<Domain.Entities.User, BookResponse>();
    }
}
