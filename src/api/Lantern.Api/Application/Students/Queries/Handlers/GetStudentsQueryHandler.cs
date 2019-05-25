using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Domain.Students;
using Lantern.Domain.Students.Services;
using MediatR;

namespace Lantern.Api.Application.Students.Queries.Handlers
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, IEnumerable<Student>>
    {
        private readonly IStudentService _studentService;

        public GetStudentsQueryHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public async Task<IEnumerable<Student>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetAll();
            
            return students;
        }
    }
}