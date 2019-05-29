using Lantern.Core.SeedWork;

namespace Lantern.Core.Services.Enrollments.Exceptions
{
    public class StudentAlreadyEnrolledException : BusinessException
    {
        public StudentAlreadyEnrolledException(string studentname, string subjectname) 
            : base($"Student {studentname} already enrolled on subject {subjectname}")
        {
        }
    }
}