using System;

namespace Lantern.Domain.SeedWork
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}