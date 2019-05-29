using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lantern.Domain.SeedWork
{
    public interface IDomainEventsService
    {
        Task Publish(IEnumerable<IDomainEvent> domainEvents);
    }
}