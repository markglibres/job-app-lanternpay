using System;

namespace Lantern.Domain.Models
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
    }
}