using AutoMapper;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.BookCirculation.Commands;

namespace TomeTracker.Application.UseCases.Mappers;

public class BookCirculationMapper:Profile
{
    public BookCirculationMapper()
    {
        CreateMap<CreateCirculationRequest, Domain.Aggregates.Circulations.BookCirculation>();
        CreateMap<Domain.Aggregates.Circulations.BookCirculation, BookCirculationResponse>();
    }
}
