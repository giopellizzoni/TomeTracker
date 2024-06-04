using AutoMapper;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.User.Commands;

namespace TomeTracker.Application.UseCases.Mappers;

public class UserMapper: Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserRequest, Domain.Aggregates.Users.User>();
        CreateMap<Domain.Aggregates.Users.User, UserResponse>();
    }
}
