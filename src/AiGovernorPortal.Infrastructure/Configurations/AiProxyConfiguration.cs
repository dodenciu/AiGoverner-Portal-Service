using AiGovernorPortal.Domain.AiProxies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AiGovernorPortal.Infrastructure.Configurations;

internal sealed class AiProxyConfiguration : IEntityTypeConfiguration<AiProxy>
{
    public void Configure(EntityTypeBuilder<AiProxy> builder)
    {
        builder.ToTable("ai_proxies");
        builder.HasKey(aiProxy => aiProxy.Id);
        builder.Property(aiProxy => aiProxy.Id)
            .HasConversion(
                aiProxyId => aiProxyId.Value,
                value => new AiProxyId(value));
        builder.Property(aiProxy => aiProxy.Name)
            .HasMaxLength(200)
            .HasConversion(
                aiProxyName => aiProxyName.Value,
                value => new AiProxyName(value));

        builder.Property(aiProxy => aiProxy.Description)
            .HasMaxLength(2000)
            .HasConversion(
                aiProxyDescription => aiProxyDescription.Value,
                value => new AiProxyDescription(value));
    }
}