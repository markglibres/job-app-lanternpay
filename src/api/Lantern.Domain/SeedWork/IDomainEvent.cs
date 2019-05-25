using System;

namespace Lantern.Domain.SeedWork
{
    public interface IDomainEvent
    {
        Guid Id { get; }
    }
}