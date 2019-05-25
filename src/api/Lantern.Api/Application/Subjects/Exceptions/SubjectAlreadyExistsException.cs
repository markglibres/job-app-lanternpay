using System;

namespace Lantern.Api.Application.Subjects.Exceptions
{
    public class SubjectAlreadyExistsException : Exception
    {
        public SubjectAlreadyExistsException(string requestName)
        {
            throw new NotImplementedException();
        }
    }
}