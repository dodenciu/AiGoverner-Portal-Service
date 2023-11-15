using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.AiProxies;
using AiGovernorPortal.Domain.Licenses;
using AiGovernorPortal.Domain.Tenants.Events;
using AiGovernorPortal.Domain.Vaults;

namespace AiGovernorPortal.Domain.Tenants;
public sealed class Tenant : Entity<TenantId>
{
    public Tenant(
        TenantId tenantId,
        Name name,
        Subdomain subdomain,
        Contact contact,
        DateTime createdOnUtc) : base(tenantId)
    {
        Name = name;
        Subdomain = subdomain;
        Contact = contact;
        CreatedOnUtc = createdOnUtc;
        AiProxies = new();
        Vaults = new();
    }

    private Tenant()
    {
    }

    public LicenseId LicenseId { get; private set; }
    public Name Name { get; private set; }
    public Subdomain Subdomain { get; private set; }
    public Contact Contact { get; private set; }
    public List<AiProxy> AiProxies { get; private set; }
    public List<Vault> Vaults { get; private set; }
    public TenantStatus Status { get; private set; }
    public DateTime CreatedOnUtc { get; private set; }
    public DateTime? ActivatedOnUtc { get; private set; }
    public DateTime? TerminatedOnUtc { get; private set; }

    public Result AssignLicense(License license, CapabilitiesService capabilitiesService)
    {
        if (license.Status != LicenseStatus.Validated)
        {
            return Result.Failure(TenantErrors.InvalidLicense);
        }
        var capabilities = capabilitiesService.GetCapabilities(license);
        LicenseId = license.Id;
        AiProxies = capabilities.AvailableAiProxies;
        Vaults = capabilities.AvailableAiVaults;

        RaiseDomainEvent(new LicenseAssignedDomainEvent(license.Id));

        return Result.Success();
    }
}