using System;
using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Students.Exceptions
{
    public class StudentMissingNameException : BusinessException
    {
        public StudentMissingNameException()
         : base($"Student name required")
        {
            
        }
    }
}