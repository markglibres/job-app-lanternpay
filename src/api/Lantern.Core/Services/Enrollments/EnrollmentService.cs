using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Enrollments.Services;
using Lantern.Domain.Lectures.Services;
using Lantern.Domain.SeedWork;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects;
using Lantern.Domain.Subjects.Services;

namespace Lantern.Core.Services.Enrollments
{
    public class EnrollmentService: IEnrollmentService
    {
        private readonly IRepository<Enrollment> _repository;
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly ILectureTheatreService _lectureTheatreService;
        private readonly IDomainEventsService _domainEventsService;

        public EnrollmentService(
            IRepository<Enrollment> repository,
            IStudentService studentService,
            ISubjectService subjectService,
            ILectureTheatreService lectureTheatreService,
            IDomainEventsService domainEventsService)
        {
            _repository = repository;
            _studentService = studentService;
            _subjectService = subjectService;
            _lectureTheatreService = lectureTheatreService;
            _domainEventsService = domainEventsService;
        }
        
        public async Task<bool> IsExists(Guid applicationId)
        {
            return (await _repository
                .FindByPredicate(_ => _.ApplicationId == applicationId))
                .Any();
        }

        public async Task<Student> GetStudent(Guid applicationId)
        {
            var enrollment = await GetByApplicationId(applicationId);
            var student = await _studentService.GetById(enrollment.StudentId);

            return student;
        }

        public async Task<Subject> GetSubject(Guid applicationId)
        {
            var enrollment = await GetByApplicationId(applicationId);
            var subject = await _subjectService.GetById(enrollment.SubjectId);

            return subject;
        }

        public Enrollment Create(Guid applicationId, Guid subjectId, Guid studentId)
        {
            var enrollment =  new Enrollment(applicationId, subjectId, studentId);
            return enrollment;
        }

        public async Task<bool> ExceedsCapacity(Guid subjectId)
        {
            var subject = await _subjectService.GetById(subjectId);
            var lectureTheatreIds = subject.Lectures
                .Select(_ => _.LectureTheatreId);

            var theatres = await _lectureTheatreService.GetById(lectureTheatreIds);

            var minCapacity = theatres
                .Select(_ => _.Capacity)
                .Min();

            var studentCount = subject.Students.Count;

            return studentCount + 1 > minCapacity;

        }

        public async Task Save(Enrollment enrollment)
        {
            await _repository.SaveAsync(enrollment);
            
            _domainEventsService.Publish(enrollment.Events);
        }

        public async Task<bool> ExceedsStudentHours(Guid subjectId, Guid studentId)
        {
            var subjectTotalHours = await _subjectService.GetTotalHours(subjectId);
            var studentTotalHours = await GetStudentHours(studentId);

            return subjectTotalHours + studentTotalHours > 10;
        }

        public async Task<Enrollment> GetByApplicationId(Guid applicationId)
        {
            return (await _repository.FindByPredicate(_ => _.ApplicationId == applicationId))
                .FirstOrDefault();
        }

        public async Task<double> GetStudentHours(Guid studentId)
        {
            var subjectsByStudent = await _subjectService.GetAllByStudentId(studentId);

            double totalHours = 0;
            
            subjectsByStudent.ToList().ForEach(subject =>  
                totalHours += subject.Lectures
                    .Select(_ => (_.EndTime - _.StartTime).TotalHours)
                    .Sum());

            return totalHours;
        }
    }
}