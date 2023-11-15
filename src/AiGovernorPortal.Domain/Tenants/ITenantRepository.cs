namespace AiGovernorPortal.Domain.Tenants;
public interface ITenantRepository
{
    Task<Tenant?> GetByIdAsync(TenantId id, CancellationToken cancellationToken);

    void Add(Tenant tenant);
    void Update(Tenant tenant);
}
