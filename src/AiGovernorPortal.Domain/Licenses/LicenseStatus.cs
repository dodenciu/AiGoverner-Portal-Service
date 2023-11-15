namespace AiGovernorPortal.Domain.Licenses;

public enum LicenseStatus
{
    PendingValidation = 1,
    Validated = 2,
    Active = 3,
    Invalid = 4,
    Expired = 5,
}