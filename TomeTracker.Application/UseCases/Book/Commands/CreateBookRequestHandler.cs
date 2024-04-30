using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Commands;

public class CreateBookRequestHandler: BaseHandler, IRequestHandler<CreateBookRequest, BookResponse>
{
    public CreateBookRequestHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<BookResponse> Handle(
        CreateBookRequest request,
        CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Domain.Entities.Book>(request);
        await _unitOfWork.BeginTransactionAsync();
        _unitOfWork.Books.Create(book);

        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<BookResponse>(book);
    }
}
