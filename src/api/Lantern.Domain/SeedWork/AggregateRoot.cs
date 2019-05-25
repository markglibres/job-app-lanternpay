using System.Collections.Generic;
using Lantern.Domain.Models;

namespace Lantern.Domain.SeedWork
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