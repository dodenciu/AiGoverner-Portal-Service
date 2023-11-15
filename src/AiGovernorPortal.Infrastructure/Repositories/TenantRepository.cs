using AiGovernorPortal.Domain.Tenants;

namespace AiGovernorPortal.Infrastructure.Repositories;

internal sealed class TenantRepository : Repository<Tenant, TenantId>, ITenantRepository
{
    public TenantRepository(ApplicationDbContext dbContext)
        : base(dbContext)
    {
    }

    public void Update(Tenant tenant)
    {
        DbContext.Update(tenant);
    }
}