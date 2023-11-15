using AiGovernorPortal.Domain.Abstractions;
using MediatR;

namespace AiGovernorPortal.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}