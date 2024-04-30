using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Queries;

public sealed class GetAllBooksQueryHandler: BaseHandler, IRequestHandler<GetAllBooksQuery, List<BookResponse>>
{
    public GetAllBooksQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<List<BookResponse>> Handle(
        GetAllBooksQuery request,
        CancellationToken cancellationToken)
    {
        var books = await _unitOfWork.Books.GetAll(cancellationToken);
        var booksResponse = _mapper.Map<List<BookResponse>>(books);

        return booksResponse;
    }
}
