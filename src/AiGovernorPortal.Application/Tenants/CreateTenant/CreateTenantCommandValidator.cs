using FluentValidation;

namespace AiGovernorPortal.Application.Tenants.CreateTenant;

public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Company).NotEmpty();
        RuleFor(c => c.Email).EmailAddress();
        RuleFor(c => c.Subdomain).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}