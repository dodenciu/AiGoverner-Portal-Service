using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Vaults;

namespace AiGovernorPortal.Domain.Features.Events;

public sealed record VaultCreatedDomainEvent(VaultId UserId) : IDomainEvent;