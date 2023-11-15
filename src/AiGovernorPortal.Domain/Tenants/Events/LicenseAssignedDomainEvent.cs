using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Licenses;

namespace AiGovernorPortal.Domain.Tenants.Events;

public sealed record LicenseAssignedDomainEvent(LicenseId licenseId) : IDomainEvent;