using AutoMapper;

using MediatR;

using TomeTracker.Application.Models;
using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Book.Commands;

public class CreateBookRequestHandler: IRequestHandler<CreateBookRequest, BookResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;

    public CreateBookRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookResponse> Handle(
        CreateBookRequest request,
        CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Domain.Entities.Book>(request);
        await unitOfWork.BeginTransactionAsync();
        unitOfWork.Books.Create(book);

        await unitOfWork.CommitTransactionAsync();

        return _mapper.Map<BookResponse>(book);
    }
}
