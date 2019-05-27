using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Subjects.ResponseModels;
using Lantern.Core.Services.Subjects.Exceptions;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Subjects.Commands.Handlers
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, SubjectResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;

        public CreateSubjectCommandHandler(
            IMapper mapper,
            ISubjectService subjectService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
        }

        public async Task<SubjectResponseModel> Handle(CreateSubjectCommand request,
            CancellationToken cancellationToken)
        {
            var subject = await _subjectService.Create(request.Name);

            var response = _mapper.Map<SubjectResponseModel>(subject);
            
            return response;
        }
    }

}