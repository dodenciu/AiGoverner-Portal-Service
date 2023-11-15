//using AiGovernorPortal.Domain.Licenses;
//using AiGovernorPortal.Domain.Tenants;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace AiGovernorPortal.Infrastructure.Configurations;

//internal sealed class LicenseConfiguration : IEntityTypeConfiguration<License>
//{
//    public void Configure(EntityTypeBuilder<License> builder)
//    {
//        builder.ToTable("licenses");
//        builder.HasKey(license => license.Id);
//        builder.Property(license => license.Id)
//            .HasConversion(
//                licenseId => licenseId.Value,
//                value => new LicenseId(value));

//        builder.HasOne<LicenseTemplate>().WithMany();

//        builder.HasOne<Tenant>().WithMany();
//    }
//}
