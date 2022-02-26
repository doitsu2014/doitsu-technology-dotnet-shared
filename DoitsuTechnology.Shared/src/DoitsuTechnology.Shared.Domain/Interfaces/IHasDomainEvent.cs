namespace DoitsuTechnology.Shared.Domain.Interfaces;

public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents { get; set; }
}