using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Licenses.Events;
using AiGovernorPortal.Domain.Tenants;

namespace AiGovernorPortal.Domain.Licenses;

public class License : Entity<LicenseId>
{
    public TenantId TenantId { get; private set; }
    public LicenseTemplate LicenseTemplate { get; private set; }
    public LicenseStatus Status { get; private set; }
    public DateTime GeneratedOnUtc { get; private set; }
    public DateTime ExpiresOnUtc { get; private set; }

    private License(
        LicenseId id,
        TenantId tenantId,
        LicenseTemplate template) : base(id)
    {
        TenantId = tenantId;
        LicenseTemplate = template;
    }

    private License()
    {
    }

    public static License Generate(
        TenantId tenantId,
        LicenseTemplate template,
        DateTime utcNow)
    {
        var license = new License(LicenseId.New(), tenantId, template)
        {
            Status = LicenseStatus.PendingValidation,
            GeneratedOnUtc = utcNow,
            ExpiresOnUtc = utcNow + template.DurationMonths
        };

        license.RaiseDomainEvent((new LicenseCreatedDomainEvent(license.Id, tenantId)));

        return license;
    }

    public void Validate()
    {
        Status = LicenseStatus.Validated;
    }
}