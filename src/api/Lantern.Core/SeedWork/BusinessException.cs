using System;

namespace Lantern.Core.SeedWork
{
    public abstract class BusinessException : Exception
    {
        public BusinessException(string message)
            : base(message)
        {
            
        }

    }
}