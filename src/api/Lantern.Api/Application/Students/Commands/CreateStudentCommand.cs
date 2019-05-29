using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Domain.Students;
using MediatR;

namespace Lantern.Api.Application.Students.Commands
{
    public class CreateStudentCommand : IRequest<StudentResponseModel>
    {
        public string Name { get; set; }
    }
}