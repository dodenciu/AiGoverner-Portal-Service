using AiGovernorPortal.Application.Abstractions.Behaviors;
using AiGovernorPortal.Domain.Tenants;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AiGovernorPortal.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            configuration.AddOpenBehavior(typeof(LoggingBehavior<,>));

            configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddTransient<CapabilitiesService>();

        return services;
    }
}