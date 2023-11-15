using AiGovernorPortal.Domain.Vaults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AiGovernorPortal.Infrastructure.Configurations;
internal sealed class VaultConfiguration : IEntityTypeConfiguration<Vault>
{
    public void Configure(EntityTypeBuilder<Vault> builder)
    {
        builder.ToTable("vaults");
        builder.HasKey(vault => vault.Id);
        builder.Property(vault => vault.Id)
            .HasConversion(
                vaultId => vaultId.Value,
                value => new VaultId(value));
    }
}
