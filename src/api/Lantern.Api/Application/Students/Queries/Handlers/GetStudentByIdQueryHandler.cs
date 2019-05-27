using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Core.Services.Students.Exceptions;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using MediatR;

namespace Lantern.Api.Application.Students.Queries.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly IStudentService _studentService;

        public GetStudentByIdQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            if(!await _studentService.IsExists(request.Id)) 
                throw new StudentIdDoesNotExistsException(request.Id.ToString());

            var student = await _studentService.GetById(request.Id);

            return student;
        }
    }
}