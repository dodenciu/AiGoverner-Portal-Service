namespace AiGovernorPortal.Domain.Features;

public record FeatureId(Guid Value)
{
    public static FeatureId New() => new(Guid.NewGuid());
}