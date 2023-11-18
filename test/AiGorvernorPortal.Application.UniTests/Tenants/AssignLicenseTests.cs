using AiGovernorPortal.Application.Tenants.AssignLicense;
using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Domain.Licenses;
using AiGovernorPortal.Domain.Tenants;
using Bogus;
using FluentAssertions;
using NSubstitute;

namespace AiGorvernorPortal.Application.UniTests.Tenants;

public class AssignLicenseTests
{
    private static Tenant GetTenant()
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

        return tenant;
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenTenantIdIsNull()
    {
        // Arrange
        var command = new AssignLicenseCommand(
            Guid.NewGuid(),
            Guid.NewGuid());

        var tenantRepository = Substitute.For<ITenantRepository>();
        tenantRepository
            .GetByIdAsync(Arg.Any<TenantId>(), CancellationToken.None)
            .Returns((Tenant?)null);

        var handler = new AssignLicenseCommandHandler(
            tenantRepository,
            Substitute.For<ILicenseRepository>(),
            Substitute.For<IUnitOfWork>(),
            Substitute.For<CapabilitiesService>());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Error.Should().Be(TenantErrors.NotFound);
    }

    [Fact]
    public async Task Handle_ShouldReturnFailure_WhenLicenseIdIsNull()
    {
        // Arrange
        var command = new AssignLicenseCommand(
            Guid.NewGuid(),
            Guid.NewGuid());

        var tenantRepository = Substitute.For<ITenantRepository>();
        tenantRepository
            .GetByIdAsync(Arg.Any<TenantId>(), CancellationToken.None)
            .Returns(GetTenant());

        var licenseRepository = Substitute.For<ILicenseRepository>();
        licenseRepository
            .GetByIdAsync(Arg.Any<LicenseId>(), CancellationToken.None)
            .Returns((License?)null);

        var handler = new AssignLicenseCommandHandler(
            tenantRepository,
            licenseRepository,
            Substitute.For<IUnitOfWork>(),
            Substitute.For<CapabilitiesService>());

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        result.Error.Should().Be(LicenseErrors.NotFound);
    }
}