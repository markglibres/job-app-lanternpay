using System;

namespace Lantern.Domain.Models
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; protected set; }
    }
}