using System.Collections.Generic;

namespace Lantern.Domain.Models
{
    public interface IHasDomainEvents
    {
        IEnumerable<IDomainEvent> Events { get; }
        void Emit(IDomainEvent domainEvent);
    }
}