namespace AiGovernorPortal.Domain.AiProxies;

public record AiProxyId(Guid Value)
{
    public static AiProxyId New() => new(Guid.NewGuid());
}