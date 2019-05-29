using System.Collections.Generic;

namespace Lantern.Domain.SeedWork
{
    public interface IHasDomainEvents
    {
        List<IDomainEvent> Events { get; }
        void Emit(IDomainEvent domainEvent);
    }
}