namespace AiGovernorPortal.Domain.Licenses;

public interface ILicenseRepository
{
    public Task<License?> GetByIdAsync(LicenseId licenseId, CancellationToken cancellationToken);
}