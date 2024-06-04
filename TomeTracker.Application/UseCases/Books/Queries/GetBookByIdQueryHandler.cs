using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Queries;

public class GetBookByIdQueryHandler : BaseHandler, IRequestHandler<GetBookByIdQuery, BookResponse?>
{

    public GetBookByIdQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<BookResponse?> Handle(
        GetBookByIdQuery request,
        CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.GetById(request.Id, cancellationToken);

        return _mapper.Map<BookResponse>(book);
    }
}
