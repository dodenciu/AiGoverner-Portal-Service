using AiGovernorPortal.Application.Abstractions.Messaging;

namespace AiGovernorPortal.Application.Tenants.ListTenants;

public sealed record ListTenantsQuery(int Page, int PageSize)
    : IQuery<IReadOnlyList<TenantResponse>>;
