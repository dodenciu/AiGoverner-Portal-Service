namespace AiGovernorPortal.Application.Tenants.ListTenants;

public sealed class TenantResponse
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Subdomain { get; init; }
    public int Status { get; init; }
    public DateOnly CreatedOnUtc { get; init; }
    public ContactResponse Contact { get; set; }
}