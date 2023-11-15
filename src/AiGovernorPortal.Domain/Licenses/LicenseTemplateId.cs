namespace AiGovernorPortal.Domain.Licenses;

public record LicenseTemplateId(Guid Value)
{
    public static LicenseTemplateId New() => new(Guid.NewGuid());
}