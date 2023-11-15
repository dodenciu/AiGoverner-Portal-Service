using AiGovernorPortal.Domain.Abstractions;
using MediatR;

namespace AiGovernorPortal.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}