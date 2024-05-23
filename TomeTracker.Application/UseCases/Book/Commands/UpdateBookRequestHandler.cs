using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Application.UseCases.Base;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Commands;

public sealed class UpdateBookRequestHandler : BaseHandler, IRequestHandler<UpdateBookRequest, BookResponse>
{
    public UpdateBookRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper) : base(unitOfWork, mapper)
    {
    }

    public async Task<BookResponse> Handle(
        UpdateBookRequest request,
        CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.Get(request.Id, cancellationToken);
        await _unitOfWork.BeginTransactionAsync();

        book?.Update(request.Title, request.Author, request.ISBN, request.PublishingYear);
        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<BookResponse>(book);
    }
}
