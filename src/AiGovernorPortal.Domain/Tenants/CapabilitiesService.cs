using AiGovernorPortal.Domain.AiProxies;
using AiGovernorPortal.Domain.Licenses;
using AiGovernorPortal.Domain.Shared;
using AiGovernorPortal.Domain.Vaults;

namespace AiGovernorPortal.Domain.Tenants;

//TODO Make this a smart service
public class CapabilitiesService
{
    public Capabilities GetCapabilities(License license)
    {
        var availableAiProxies = new List<AiProxy>();
        var availableAiVaults = new List<Vault>();

        var proxyTypes = new HashSet<AiType>(license
            .LicenseTemplate
            .Features
            .SelectMany(feature => feature.AiProxies));

        foreach (var proxyType in proxyTypes)
        {
            availableAiProxies.Add(AiProxy.CreateDynamic(proxyType));
        }

        var vaultTypes = new HashSet<VaultType>(license
            .LicenseTemplate
            .Features
            .SelectMany(feature => feature.Storage));

        foreach (var vaultType in vaultTypes)
        {
            availableAiVaults.Add(Vault.Create(20_000, vaultType));
        }

        return new Capabilities(availableAiProxies, availableAiVaults);
    }
}