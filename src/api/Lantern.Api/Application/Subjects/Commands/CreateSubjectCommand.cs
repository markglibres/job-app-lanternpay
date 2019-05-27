using Lantern.Api.Application.Subjects.ResponseModels;
using MediatR;

namespace Lantern.Api.Application.Subjects.Commands
{
    public class CreateSubjectCommand : IRequest<SubjectResponseModel>
    {
        public string Name { get; set; }
    }
}