using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries.Handlers
{
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, Domain.Subjects.Subject>
    {
        private readonly ISubjectService _subjectService;

        public GetSubjectByIdQueryHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        
        public async Task<Domain.Subjects.Subject> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            if(!await _subjectService.IsExists(request.Id)) throw new SubjectDoesNotExistsException();

            var subject = await _subjectService.GetById(request.Id);

            return subject;
        }
    }
}