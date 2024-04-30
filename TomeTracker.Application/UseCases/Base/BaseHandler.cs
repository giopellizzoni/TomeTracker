using AutoMapper;

using TomeTracker.Domain.Repositories;

namespace TomeTracker.Application.UseCases.Base;

public class BaseHandler
{
    protected readonly IUnitOfWork _unitOfWork;
    protected readonly IMapper _mapper;

    protected BaseHandler(IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
}
