using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Students.Exceptions;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using MediatR;

namespace Lantern.Api.Application.Students.Commands.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly IStudentService _studentService;

        public CreateStudentCommandHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name)) throw new StudentMissingNameException(request.Name);

            var student = await _studentService.Create(request.Name);

            await _studentService.Save(student);

            return student;
        }
    }
}