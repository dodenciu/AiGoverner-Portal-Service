namespace AiGovernorPortal.Domain.Vaults;

public record VaultId(Guid Value)
{
    public static VaultId New() => new(Guid.NewGuid());
}