using System;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Commands.Handlers
{
    public class CreateEnrollmentCommandHandler : IRequestHandler<CreateEnrollmentCommand, Guid>
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public CreateEnrollmentCommandHandler(
            IStudentService studentService,
            ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        }
        public async Task<Guid> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            if (!await _studentService.IsExists(request.StudentId)) throw new StudentDoesNotExistsException();

            if (!await _subjectService.IsExists(request.SubjectId)) throw new SubjectDoesNotExistsException();

            var subject = await _subjectService.GetById(request.SubjectId);
            var student = await _studentService.GetById(request.StudentId);

            var enrollmentId = subject.Enroll(student);

            return enrollmentId;

        }
    }

    public class SubjectDoesNotExistsException : Exception
    {
    }

    public class StudentDoesNotExistsException : Exception
    {
    }
}