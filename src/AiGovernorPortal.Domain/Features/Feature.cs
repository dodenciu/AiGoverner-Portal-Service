using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Shared;

namespace AiGovernorPortal.Domain.Features;

public sealed class Feature : Entity<FeatureId>
{
    public FeatureName Name { get; private set; }
    public FeatureState State { get; private set; }
    public FeatureDescription Description { get; private set; }
    public List<AiType> AiProxies { get; private set; } = new();
    public List<VaultType> Storage { get; private set; } = new();

    public Feature(
        FeatureName name,
        FeatureState state,
        FeatureDescription description,
        List<AiType> aiProxies,
        List<VaultType> storage)
    {
        Name = name;
        State = state;
        Description = description;
        AiProxies = aiProxies;
        Storage = storage;
    }

    private Feature()
    {
    }

    public void MoveFeatureInPreview() => State = FeatureState.Preview;
    public void MoveFeatureInReleased() => State = FeatureState.Released;
    public void MoveFeatureInPlanned() => State = FeatureState.Planned;
}