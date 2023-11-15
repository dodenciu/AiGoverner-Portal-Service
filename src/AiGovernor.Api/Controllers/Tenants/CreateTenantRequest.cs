namespace AiGovernor.Api.Controllers.Tenants;

public sealed record CreateTenantRequest(
    string Name,
    string Subdomain,
    string Email,
    string Address,
    string Company);
