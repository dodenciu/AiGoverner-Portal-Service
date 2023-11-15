using AiGovernorPortal.Domain.AiProxies;
using AiGovernorPortal.Domain.Vaults;

namespace AiGovernorPortal.Domain.Tenants;

public record Capabilities(
    List<AiProxy> AvailableAiProxies,
    List<Vault> AvailableAiVaults);
