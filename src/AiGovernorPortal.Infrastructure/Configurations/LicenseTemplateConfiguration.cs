//using AiGovernorPortal.Domain.Features;
//using AiGovernorPortal.Domain.Licenses;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AiGovernorPortal.Infrastructure.Configurations;
//internal sealed class LicenseTemplateConfiguration : IEntityTypeConfiguration<LicenseTemplate>
//{
//    public void Configure(EntityTypeBuilder<LicenseTemplate> builder)
//    {
//        builder.ToTable("license_templates");
//        builder.HasKey(licenseTemplate => licenseTemplate.Id);
//        builder.Property(licenseTemplate => licenseTemplate.Id)
//            .HasConversion(
//                licenseTemplateId => licenseTemplateId.Value,
//                value => new LicenseTemplateId(value));
//        builder.HasMany<Feature>().WithOne();
//    }
//}
