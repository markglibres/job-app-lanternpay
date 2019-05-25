using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lantern.Domain.Students;
using Lantern.Domain.Subjects;

namespace Lantern.Domain.Enrollments.Services
{
    public interface IEnrollmentService
    {
        Task<bool> IsExists(Guid enrollmentId);
        Task<Student> GetStudent(Guid enrollmentId);
        Task<Domain.Subjects.Subject> GetSubject(Guid notificationEnrollmentId);
        Task<Enrollment> Create(
            Guid notificationEnrollmentId, 
            Guid notificationSubjectId, 
            Guid notificationStudentId);

        Task<bool> ExceedsCapacity(Guid notificationSubjectId);
        Task Save(Enrollment enrollment);
        Task<bool> ExceedsStudentHours(Guid notificationSubjectId, Guid notificationStudentId);
    }
}