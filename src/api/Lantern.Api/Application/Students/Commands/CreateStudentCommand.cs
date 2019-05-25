using Lantern.Domain.Students;
using MediatR;

namespace Lantern.Api.Application.Students.Commands
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public string Name { get; set; }
    }
}