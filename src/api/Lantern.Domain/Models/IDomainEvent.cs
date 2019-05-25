using System;

namespace Lantern.Domain.Models
{
    public interface IDomainEvent
    {
        Guid Id { get; }
    }
}