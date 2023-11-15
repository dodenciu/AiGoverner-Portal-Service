using AiGovernorPortal.Domain.Abstractions;

namespace AiGovernorPortal.Domain.Tenants;
public static class TenantErrors
{
    public static Error InvalidLicense = new(
        "Tenant.NotAllowedLicense",
        "Only available licenses can be assigned");

    public static Error NotFound = new(
        "Tenant.NotFound",
        "No tenant found with given id");
}
