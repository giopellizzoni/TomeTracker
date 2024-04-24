using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Queries;

public class GetBookByIdQueryHandler: IRequestHandler<GetBookByIdQuery, BookResponse?>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;
    public GetBookByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookResponse?> Handle(
        GetBookByIdQuery request,
        CancellationToken cancellationToken)
    {
        var book = await unitOfWork.Books.Get(request.Id, cancellationToken);
        return _mapper.Map<BookResponse>(book);
    }
}
