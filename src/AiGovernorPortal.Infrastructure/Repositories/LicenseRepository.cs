using AiGovernorPortal.Domain.Licenses;

namespace AiGovernorPortal.Infrastructure.Repositories;
internal sealed class LicenseRepository : Repository<License, LicenseId>, ILicenseRepository
{
    public LicenseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
