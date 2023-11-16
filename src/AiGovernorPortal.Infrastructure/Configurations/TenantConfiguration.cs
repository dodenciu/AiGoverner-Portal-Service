using AiGovernorPortal.Domain.Tenants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AiGovernorPortal.Infrastructure.Configurations;

internal sealed class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> builder)
    {
        builder.ToTable("tenants");
        builder.HasKey(tenant => tenant.Id);
        builder.Property(tenant => tenant.Id)
            .HasConversion(
                tenantId => tenantId.Value,
                value => new TenantId(value));
        builder.Property(tenant => tenant.Name)
            .HasConversion(
                tenantName => tenantName.Value,
                value => new Name(value));
        builder.Property(tenant => tenant.Subdomain)
            .HasConversion(
                tenantSubdomain => tenantSubdomain.Value,
                value => new Subdomain(value));
        builder.OwnsOne(tenant => tenant.Contact);
    }
}