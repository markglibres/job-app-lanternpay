using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lantern.Domain.SeedWork
{
    public abstract class AggregateRoot : Entity, IHasDomainEvents
    {
        [IgnoreDataMember] 
        public List<IDomainEvent> Events { get; protected set; }
        
        public void Emit(IDomainEvent domainEvent)
        {
            if(Events == null) Events = new List<IDomainEvent>();
            
            Events.Add(domainEvent);
        }
    }
}