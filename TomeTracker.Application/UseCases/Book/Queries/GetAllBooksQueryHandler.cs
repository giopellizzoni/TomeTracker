using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Queries;

public sealed class GetAllBooksQueryHandler: IRequestHandler<GetAllBooksQuery, List<BookResponse>>
{
    private readonly IUnityOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllBooksQueryHandler(IUnityOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
