using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries.Handlers
{
    public class GetStudentsBySubjectIdQueryHandler : IRequestHandler<GetStudentsBySubjectIdQuery, GetStudentsBySubjectIdQueryModel>
    {
        private readonly ISubjectService _subjectService;

        public GetStudentsBySubjectIdQueryHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        
        public async Task<GetStudentsBySubjectIdQueryModel> Handle(GetStudentsBySubjectIdQuery request, CancellationToken cancellationToken)
        {
            if(!await _subjectService.IsExists(request.Id)) throw new SubjectDoesNotExistsException();

            var subject = await _subjectService.GetById(request.Id);
            
            var response = new GetStudentsBySubjectIdQueryModel
            {
                Id = subject.Id,
                Name = subject.Name,
                Students = subject.Students
            };

            return response;
        }
    }
}