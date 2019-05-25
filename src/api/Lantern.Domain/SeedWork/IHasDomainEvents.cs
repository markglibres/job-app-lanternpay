using System.Collections.Generic;

namespace Lantern.Domain.SeedWork
{
    public interface IHasDomainEvents
    {
        IEnumerable<IDomainEvent> Events { get; }
        void Emit(IDomainEvent domainEvent);
    }
}