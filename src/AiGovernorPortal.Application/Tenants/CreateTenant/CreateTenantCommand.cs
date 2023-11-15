using AiGovernorPortal.Application.Abstractions.Messaging;

namespace AiGovernorPortal.Application.Tenants.CreateTenant;

public record CreateTenantCommand(
    string Name,
    string Subdomain,
    string Email,
    string Address,
    string Company) : ICommand<Guid>;