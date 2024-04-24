using AutoMapper;

using TomeTracker.Application.UseCases.Book.Models;

namespace TomeTracker.Application.UseCases.Book.Mappers;

public class BookMapper : Profile
{
    public BookMapper()
    {
        CreateMap<BookRequest, Domain.Entities.Book>();
        CreateMap<Domain.Entities.Book, BookResponse>();
    }
}
