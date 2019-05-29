using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lantern.Domain.Students;
using Lantern.Domain.Subjects;

namespace Lantern.Domain.Enrollments.Services
{
    public interface IEnrollmentService
    {
        Task<bool> IsExists(Guid applicationId);
        Task<Student> GetStudent(Guid applicationId);
        Task<Domain.Subjects.Subject> GetSubject(Guid applicationId);
        Enrollment Create(
            Guid applicationId, 
            Guid subjectId, 
            Guid studentId);

        Task<bool> ExceedsCapacity(Guid subjectId);
        Task Save(Enrollment enrollment);
        Task<bool> ExceedsStudentHours(Guid subjectId, Guid studentId);
        Task<Enrollment> GetByApplicationId(Guid applicationId);
        Task<double> GetStudentHours(Guid studentId);
        Task<IEnumerable<Enrollment>> GetAll();
    }
}