using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Features.Events;
using AiGovernorPortal.Domain.Shared;

namespace AiGovernorPortal.Domain.Vaults;

public class Vault : Entity<VaultId>
{
    public int SizeInMb { get; private set; }
    public VaultType StorageType { get; private set; }
    public VaultState StorageState { get; private set; }

    private Vault(
        VaultId id,
        int sizeInMb,
        VaultType storageType)
            : base(id)
    {
        SizeInMb = sizeInMb;
        StorageType = storageType;
    }

    public static Vault Create(int sizeInMb, VaultType storageType)
    {
        var storage = new Vault(VaultId.New(), sizeInMb, storageType)
        {
            StorageState = VaultState.Scheduled
        };
        storage.RaiseDomainEvent(new VaultCreatedDomainEvent(storage.Id));
        return storage;
    }

    private Vault()
    {
    }
}