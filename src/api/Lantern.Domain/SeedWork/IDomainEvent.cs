using System;
using MediatR;

namespace Lantern.Domain.SeedWork
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }
    }
}