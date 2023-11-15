using AiGovernorPortal.Application.Abstractions.Messaging;
using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Licenses;
using AiGovernorPortal.Domain.Tenants;

namespace AiGovernorPortal.Application.Tenants.AssignLicense;

public class AssignLicenseCommandHandler : ICommandHandler<AssignLicenseCommand>
{
    private readonly ITenantRepository _tenantRepository;
    private readonly ILicenseRepository _licenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly CapabilitiesService _capabilitiesService;

    public AssignLicenseCommandHandler(
        ITenantRepository tenantRepository,
        ILicenseRepository licenseRepository,
        IUnitOfWork unitOfWork,
        CapabilitiesService capabilitiesService)
    {
        _tenantRepository = tenantRepository;
        _licenseRepository = licenseRepository;
        _unitOfWork = unitOfWork;
        _capabilitiesService = capabilitiesService;
    }
    public async Task<Result> Handle(AssignLicenseCommand request, CancellationToken cancellationToken)
    {
        var tenant = await _tenantRepository.GetByIdAsync(new TenantId(request.tenantId), cancellationToken);
        if (tenant is null)
        {
            return Result.Failure(TenantErrors.NotFound);
        }

        var license = await _licenseRepository.GetByIdAsync(new LicenseId(request.licenseId), cancellationToken);
        if (license is null)
        {
            return Result.Failure(LicenseErrors.NotFound);
        }

        var result = tenant.AssignLicense(license, _capabilitiesService);

        if (result.IsFailure)
        {
            return result;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}