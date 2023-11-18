using AiGovernorPortal.Domain.Features;
using AiGovernorPortal.Domain.Licenses;
using AiGovernorPortal.Domain.Tenants;
using AiGovernorPortal.Domain.Tenants.Events;
using Bogus;
using FluentAssertions;

namespace AiGovernorPortal.Domain.UnitTests.Tenants;

public class TenantTests : BaseTest
{
    [Fact]
    public void AssignLicense_ShouldRaiseEvent_WhenSuccess()
    {
        var faker = new Faker();
        var email = faker.Internet.Email();
        var address = faker.Address.StreetAddress();
        var company = faker.Company.CompanyName();
        var subdomain = faker.Internet.DomainWord();

        var tenant = new Tenant(
            TenantId.New(),
            new Name(company),
            new Subdomain(subdomain),
            new Contact(email, address, company),
            DateTime.UtcNow);

        var license = License.Generate(
            tenant.Id,
            new LicenseTemplate(LicenseTemplateId.New(), Array.Empty<Feature>(), 6),
            DateTime.UtcNow);

        license.Validate();

        tenant.AssignLicense(license, new CapabilitiesService());

        var licenseAssignedDomainEvent = AssertDomainEventWasPublished<LicenseAssignedDomainEvent>(tenant);

        licenseAssignedDomainEvent.TenantId.Should().Be(tenant.Id);
        licenseAssignedDomainEvent.LicenseId.Should().Be(license.Id);
    }
}