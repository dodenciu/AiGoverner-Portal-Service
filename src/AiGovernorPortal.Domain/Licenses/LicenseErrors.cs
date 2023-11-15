using AiGovernorPortal.Domain.Abstractions;

namespace AiGovernorPortal.Domain.Licenses;

public static class LicenseErrors
{
    public static Error NotFound = new(
        "License.NotFound",
        "No license found with given id");
}