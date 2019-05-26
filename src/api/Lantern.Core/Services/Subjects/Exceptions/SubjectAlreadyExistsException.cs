using System;
using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Subjects.Exceptions
{
    public class SubjectAlreadyExistsException : BusinessException
    {
        public SubjectAlreadyExistsException(string name) 
            : base($"Subject name already exists: {name}")
        {
            
        }
    }
}