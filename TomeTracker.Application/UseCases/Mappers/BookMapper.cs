using AutoMapper;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Book.Commands;

namespace TomeTracker.Application.UseCases.Mappers;

public class BookMapper : Profile
{
    public BookMapper()
    {
        CreateMap<CreateBookRequest, Domain.Entities.Book>();
        CreateMap<Domain.Entities.Book, BookResponse>();
    }
}
