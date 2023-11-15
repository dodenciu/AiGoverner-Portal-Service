using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.AiProxies;

namespace AiGovernorPortal.Domain.Features.Events;

public record AiProxyCreatedDomainEvent(AiProxyId AiProxyId) : IDomainEvent;