using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Features;

namespace AiGovernorPortal.Domain.Licenses;

public class LicenseTemplate : Entity<LicenseTemplateId>
{
    public ICollection<Feature> Features { get; private set; }
    public TimeSpan DurationMonths { get; private set; }
    public byte DurationInMonths { get; init; }

    public LicenseTemplate(
        LicenseTemplateId id,
        ICollection<Feature> features,
        byte durationInMonths) : base(id)
    {
        Features = features;
        DurationInMonths = durationInMonths;
    }

    private LicenseTemplate()
    {
    }
}