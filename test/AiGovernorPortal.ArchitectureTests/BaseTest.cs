using AiGovernorPortal.Application.Abstractions.Messaging;
using AiGovernorPortal.Domain.Abstractions;
using AiGovernorPortal.Infrastructure;
using System.Reflection;

namespace AiGovernorPortal.ArchitectureTests;

public class BaseTest
{
    protected static Assembly ApplicationAssembly => typeof(IBaseCommand).Assembly;

    protected static Assembly DomainAssembly => typeof(IEntity).Assembly;

    protected static Assembly InfrastructureAssembly => typeof(ApplicationDbContext).Assembly;
}