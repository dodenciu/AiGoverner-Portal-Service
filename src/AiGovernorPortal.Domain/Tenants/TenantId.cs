namespace AiGovernorPortal.Domain.Tenants;
public record TenantId(Guid Value)
{
    public static TenantId New() => new(Guid.NewGuid());
}
