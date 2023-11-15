using AiGovernorPortal.Application.Abstractions.Messaging;

namespace AiGovernorPortal.Application.Tenants.AssignLicense;

public record AssignLicenseCommand(
    Guid tenantId,
    Guid licenseId) : ICommand;

