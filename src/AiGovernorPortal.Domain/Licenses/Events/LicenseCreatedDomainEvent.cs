using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Tenants;

namespace AiGovernorPortal.Domain.Licenses.Events;
public sealed record LicenseCreatedDomainEvent(LicenseId LicenseId, TenantId TenantId) : IDomainEvent;
