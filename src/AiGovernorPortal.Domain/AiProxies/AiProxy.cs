using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Features.Events;
using AiGovernorPortal.Domain.Shared;

namespace AiGovernorPortal.Domain.AiProxies;

public class AiProxy : Entity<AiProxyId>
{
    private AiProxy(
        AiProxyId id,
        AiProxyName? name,
        AiProxyDescription? description,
        AiType aiType) : base(id)
    {
        Name = name;
        Description = description;
        AiType = aiType;
    }

    private AiProxy()
    {
    }

    public AiProxyName Name { get; private set; }
    public AiProxyDescription Description { get; private set; }
    public AiType AiType { get; private set; }
    public AiProxyState State { get; private set; }
    public bool IsDynamicallyCreated { get; private set; }

    public static AiProxy Create(
        AiProxyName? name,
        AiProxyDescription? description,
        AiType aiType)
    {
        var aiProxy = new AiProxy(AiProxyId.New(), name, description, aiType)
        {
            State = AiProxyState.Scheduled
        };

        aiProxy.RaiseDomainEvent(new AiProxyCreatedDomainEvent(aiProxy.Id));

        return aiProxy;
    }

    public static AiProxy CreateDynamic(AiType aiType)
    {
        var aiProxy = Create(default, default, aiType);
        aiProxy.IsDynamicallyCreated = true;
        return aiProxy;
    }
}