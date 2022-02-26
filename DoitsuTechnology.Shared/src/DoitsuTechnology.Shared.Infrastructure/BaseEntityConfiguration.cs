using DoitsuTechnology.Shared.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoitsuTechnology.Shared.Infrastructure;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
    where T : class
{
    public void Configure(EntityTypeBuilder<T> builder)
    {
        if (typeof(T).GetInterfaces().Any(x => x == typeof(IHasDomainEvent)))
        {
            builder.Ignore(x => ((IHasDomainEvent)x).DomainEvents);
        }
    }
}