using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Queries;

public class GetBookByIdQueryHandler: IRequestHandler<GetBookByIdQuery, BookResponse?>
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IMapper _mapper;
    public GetBookByIdQueryHandler(IUnityOfWork unityOfWork, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _mapper = mapper;
    }

    public async Task<BookResponse?> Handle(
        GetBookByIdQuery request,
        CancellationToken cancellationToken)
    {
        var book = await _unityOfWork.Books.Get(request.Id, cancellationToken);
        return _mapper.Map<BookResponse>(book);
    }
}
