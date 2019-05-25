using System;

namespace Lantern.Api.Application.Students.Exceptions
{
    public class StudentMissingNameException : Exception
    {
        public StudentMissingNameException(string name)
        {
            throw new NotImplementedException();
        }
    }
}