using AiGovernorPortal.Domain.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AiGovernorPortal.Infrastructure.Configurations;
internal sealed class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{
    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.ToTable("features");
        builder.HasKey(feature => feature.Id);
        builder.Property(feature => feature.Id)
            .HasConversion(
                featureId => featureId.Value,
                value => new FeatureId(value));

        builder.Property(feature => feature.Name)
            .HasConversion(
                featureName => featureName.Value,
                value => new FeatureName(value));

        builder.Property(feature => feature.Description)
            .HasConversion(
                featureDescription => featureDescription.Value,
                value => new FeatureDescription(value));
    }
}
