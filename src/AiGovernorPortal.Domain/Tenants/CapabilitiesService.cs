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
        var proxyTypes = new HashSet<AiType>(license
            .LicenseTemplate
            .Features
            .SelectMany(feature => feature.AiProxies));

        var availableAiProxies = proxyTypes
            .Select(AiProxy.CreateDynamic)
            .ToList();

        var vaultTypes = new HashSet<VaultType>(license
            .LicenseTemplate
            .Features
            .SelectMany(feature => feature.Storage));

        var availableAiVaults = vaultTypes
            .Select(vaultType => Vault.Create(20_000, vaultType))
            .ToList();

        return new Capabilities(availableAiProxies, availableAiVaults);
    }
}