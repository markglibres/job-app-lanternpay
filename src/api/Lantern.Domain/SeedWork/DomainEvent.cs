using System;
using Lantern.Domain.Models;

namespace Lantern.Domain.SeedWork
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; protected set; }
    }
}