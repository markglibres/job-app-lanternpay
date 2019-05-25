using System.Collections.Generic;

namespace Lantern.Domain.SeedWork
{
    public interface IDomainEventsService
    {
        void Publish(IEnumerable<IDomainEvent> domainEvents);
    }
}