using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Subject.Queries;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries.Handlers
{
    public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, IEnumerable<Domain.Subjects.Subject>>
    {
        private readonly ISubjectService _subjectService;

        public GetSubjectsQueryHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        public async Task<IEnumerable<Domain.Subjects.Subject>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectService.GetAll();
            return subjects;
        }
    }
}