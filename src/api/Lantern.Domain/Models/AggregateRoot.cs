using System.Collections.Generic;

namespace Lantern.Domain.Models
{
    public abstract class AggregateRoot : Entity, IHasDomainEvents
    {
        public IEnumerable<IDomainEvent> Events { get; protected set; }
        
        public void Emit(IDomainEvent domainEvent)
        {
            ((List<IDomainEvent>)Events).Add(domainEvent);
        }
    }
}