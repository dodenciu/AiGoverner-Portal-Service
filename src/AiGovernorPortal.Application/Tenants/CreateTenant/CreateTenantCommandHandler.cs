using AiGovernorPortal.Application.Abstractions.Messaging;
using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Tenants;

namespace AiGovernorPortal.Application.Tenants.CreateTenant;

internal sealed class CreateTenantCommandHandler(
        ITenantRepository tenantRepository,
        IUnitOfWork unitOfWork)
            : ICommandHandler<CreateTenantCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var tenantId = TenantId.New();
        var tenantContact = new Contact(request.Email, request.Address, request.Company);
        var tenantName = new Name(request.Name);
        var tenantSubdomain = new Subdomain(request.Subdomain);

        var tenant = new Tenant(tenantId, tenantName, tenantSubdomain, tenantContact, DateTime.Now);
        tenantRepository.Add(tenant);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return tenant.Id.Value;
    }
}