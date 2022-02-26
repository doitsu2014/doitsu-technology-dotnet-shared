using DoitsuTechnology.Shared.Domain;

namespace DoitsuTechnology.Shared.Application.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
