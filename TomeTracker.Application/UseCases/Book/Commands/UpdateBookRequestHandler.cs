using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Commands;

public sealed class UpdateBookRequestHandler: IRequestHandler<UpdateBookRequest, BookResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBookRequestHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookResponse> Handle(
        UpdateBookRequest request,
        CancellationToken cancellationToken)
    {
        var book = await _unitOfWork.Books.Get(request.Id, cancellationToken);
        await _unitOfWork.BeginTransactionAsync();

        book?.Updated(request.Title, request.Author, request.ISBN, request.PublishingYear);
        await _unitOfWork.CommitTransactionAsync();

        return _mapper.Map<BookResponse>(book);
    }
}
