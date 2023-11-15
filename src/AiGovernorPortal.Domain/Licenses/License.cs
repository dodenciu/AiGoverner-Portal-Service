using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Licenses.Events;
using AiGovernorPortal.Domain.Tenants;

namespace AiGovernorPortal.Domain.Licenses;

public class License : Entity<LicenseId>
{
    private License(
        LicenseId id,
        TenantId tenantId,
        LicenseTemplateId templateId) : base(id)
    {
        TenantId = tenantId;
        LicenseTemplateId = templateId;
    }

    private License()
    {
    }

    public TenantId TenantId { get; private set; }
    public LicenseTemplateId LicenseTemplateId { get; private set; }
    public LicenseTemplate LicenseTemplate { get; private set; }
    public LicenseStatus Status { get; private set; }
    public DateTime GeneratedOnUtc { get; private set; }
    public DateTime ExpiresOnUtc { get; private set; }

    public static License Generate(
        TenantId tenantId,
        LicenseTemplate template,
        DateTime utcNow)
    {
        var license = new License(LicenseId.New(), tenantId, template.Id)
        {
            Status = LicenseStatus.PendingValidation,
            GeneratedOnUtc = utcNow,
            ExpiresOnUtc = utcNow + template.DurationMonths
        };

        license.LicenseTemplate = template;

        license.RaiseDomainEvent((new LicenseCreatedDomainEvent(license.Id, tenantId)));

        return license;
    }
}