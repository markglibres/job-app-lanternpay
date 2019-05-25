using System;

namespace Lantern.Api.Application.Subjects.Exceptions
{
    public class SubjectMissingNameException : Exception
    {
        public SubjectMissingNameException(string requestName)
        {
            throw new NotImplementedException();
        }
    }
}