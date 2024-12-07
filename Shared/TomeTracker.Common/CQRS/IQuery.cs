using MediatR;

namespace TomeTracker.Common.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : notnull;
