using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Domain.Students.Services;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Students.Queries.Handlers
{
    public class
        GetEnrollmentsByStudentIdQueryHandler : IRequestHandler<GetEnrollmentsByStudentIdQuery,
            GetEnrollmentsByStudentIdQueryModel>
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;

        public GetEnrollmentsByStudentIdQueryHandler(
            IStudentService studentService,
            ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
        }

        public async Task<GetEnrollmentsByStudentIdQueryModel> Handle(GetEnrollmentsByStudentIdQuery request,
            CancellationToken cancellationToken)
        {
            if (!await _studentService.IsExists(request.Id)) throw new StudentDoesNotExistsException();

            var subjects = await _subjectService.GetAllByStudentId(request.Id);
            var student = await _studentService.GetById(request.Id);

            var response = new GetEnrollmentsByStudentIdQueryModel
            {
                Id = student.Id,
                Name = student.Name,
                Subjects = subjects
            };

            return response;
        }
    }
}