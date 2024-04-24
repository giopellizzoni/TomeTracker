using AutoMapper;
using MediatR;
using TomeTracker.Application.UseCases.Book.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.CreateBook;

public class CreateBookHandler: IRequestHandler<BookRequest, BookResponse>
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public CreateBookHandler(IUnityOfWork unityOfWork, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<BookResponse> Handle(
        BookRequest request,
        CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Domain.Entities.Book>(request);
        await _unityOfWork.BeginTransactionAsync();
        _unityOfWork.Books.Create(book);
        await _unityOfWork.SaveChangesAsync();

        await _unityOfWork.CommitTransactionAsync();

        return _mapper.Map<BookResponse>(book);
    }
}
