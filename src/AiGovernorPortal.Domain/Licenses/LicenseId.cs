namespace AiGovernorPortal.Domain.Licenses;

public record LicenseId(Guid Value)
{
    public static LicenseId New() => new(Guid.NewGuid());
}