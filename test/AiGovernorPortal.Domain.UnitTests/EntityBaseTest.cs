using AiGovernorPortal.Domain.Abstractions;

namespace AiGovernorPortal.Domain.UnitTests;
public abstract class EntityBaseTest
{
    public static T AssertDomainEventWasPublished<T>(IEntity entity)
        where T : IDomainEvent
    {
        var domainEvent = entity.GetDomainEvents().OfType<T>().SingleOrDefault();
        return domainEvent is null ?
            throw new Exception($"{typeof(T).Name} was not published") :
            domainEvent;
    }
}
