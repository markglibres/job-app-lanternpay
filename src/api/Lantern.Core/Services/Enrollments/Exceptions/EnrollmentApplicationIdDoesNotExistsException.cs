using System;
using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Enrollments.Exceptions
{
    public class EnrollmentApplicationIdDoesNotExistsException : BusinessException
    {
        public EnrollmentApplicationIdDoesNotExistsException(string applicationId) 
            : base($"Enrollment application id does not exist: {applicationId}")
        {
        }
    }
}