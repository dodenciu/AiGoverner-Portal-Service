using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Features;

namespace AiGovernorPortal.Domain.Licenses;

public class LicenseTemplate : Entity<LicenseTemplateId>
{
    private LicenseTemplate(
        LicenseTemplateId id,
        List<Feature> features,
        byte durationInMonths) : base(id)
    {
        Features = features;
        DurationInMonths = durationInMonths;
    }

    private LicenseTemplate()
    {
    }

    public TimeSpan DurationMonths { get; private set; }
    public List<Feature> Features { get; private set; }
    public byte DurationInMonths { get; init; }
}