using System;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Subjects.Exceptions;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Subjects.Commands.Handlers
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Domain.Subjects.Subject>
    {
        private readonly ISubjectService _subjectService;

        public CreateSubjectCommandHandler(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public async Task<Domain.Subjects.Subject> Handle(CreateSubjectCommand request,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.Name)) throw new SubjectMissingNameException(request.Name);

            if (await _subjectService.IsExists(request.Name)) throw new SubjectAlreadyExistsException(request.Name);

            var subject = await _subjectService.Create(request.Name);

            return subject;
        }
    }

}