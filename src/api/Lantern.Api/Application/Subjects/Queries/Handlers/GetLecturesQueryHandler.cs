using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries.Handlers
{
    public class GetLecturesQueryHandler : IRequestHandler<GetLecturesQuery, GetLecturesQueryModel>
    {
        private readonly ISubjectService _subjectService;

        public GetLecturesQueryHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        public async Task<GetLecturesQueryModel> Handle(GetLecturesQuery request, CancellationToken cancellationToken)
        {
            if(!await _subjectService.IsExists(request.SubjectId)) throw new SubjectDoesNotExistsException();

            var subject = await _subjectService.GetById(request.SubjectId);

            var response = new GetLecturesQueryModel
            {
                Id = subject.Id,
                Name = subject.Name,
                Lectures = subject.Lectures
            };

            return response;
        }
    }
}