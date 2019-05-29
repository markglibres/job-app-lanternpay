using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.ResponseModels;
using Lantern.Core.Services.Enrollments.Exceptions;
using Lantern.Core.Services.Students.Exceptions;
using Lantern.Core.Services.Subjects.Exceptions;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Commands.Handlers
{
    public class CreateEnrollmentCommandHandler : IRequestHandler<CreateEnrollmentCommand, CreateEnrollmentResponseModel>
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
        public async Task<CreateEnrollmentResponseModel> Handle(CreateEnrollmentCommand request, CancellationToken cancellationToken)
        {
            if (!await _studentService.IsExists(request.StudentId)) 
                throw new StudentIdDoesNotExistsException(request.StudentId.ToString());

            if (!await _subjectService.IsExists(request.SubjectId)) 
                throw new SubjectIdDoesNotExistsException(request.SubjectId.ToString());

            var subject = await _subjectService.GetById(request.SubjectId);
            var student = await _studentService.GetById(request.StudentId);

            if (subject.Students.Any(_ => _.Id == student.Id))
                throw new StudentAlreadyEnrolledException(student.Name, subject.Name);

            var applicationId = subject.Enroll(student);

            await _subjectService.Save(subject);

            return new CreateEnrollmentResponseModel{ ApplicationId = applicationId };

        }
    }

    

    
}