using MediatR;

namespace Lantern.Api.Application.Subjects.Commands
{
    public class CreateSubjectCommand : IRequest<Domain.Subjects.Subject>
    {
        public string Name { get; set; }
    }
}