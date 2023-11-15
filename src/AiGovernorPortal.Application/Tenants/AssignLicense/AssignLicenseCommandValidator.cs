using FluentValidation;

namespace AiGovernorPortal.Application.Tenants.AssignLicense;

public class AssignLicenseCommandValidator : AbstractValidator<AssignLicenseCommand>
{
    public AssignLicenseCommandValidator()
    {
        RuleFor(c => c.licenseId).NotNull();
        RuleFor(c => c.tenantId).NotNull();
    }
}