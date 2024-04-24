using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Commands;

public class CreateBookRequestHandler: IRequestHandler<CreateBookRequest, BookResponse>
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;

    public CreateBookRequestHandler(IUnityOfWork unityOfWork, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<BookResponse> Handle(
        CreateBookRequest request,
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
