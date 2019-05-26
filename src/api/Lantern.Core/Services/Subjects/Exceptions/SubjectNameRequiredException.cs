using System;
using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Subjects.Exceptions
{
    public class SubjectNameRequiredException : BusinessException
    {
        public SubjectNameRequiredException()
        : base($"Subject name is required.")
        {
            
        }
    }
}