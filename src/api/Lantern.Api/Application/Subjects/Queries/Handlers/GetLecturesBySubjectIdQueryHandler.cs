using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Mappers.Services;
using Lantern.Api.Application.Subjects.ResponseModels;
using Lantern.Core.Services.Subjects.Exceptions;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries.Handlers
{
    public class GetLecturesBySubjectIdQueryHandler : IRequestHandler<GetLecturesBySubjectIdQuery, SubjectLecturesResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly IEntityMapperService<LectureResponseModel> _entityMapperService;
        private readonly ISubjectService _subjectService;

        public GetLecturesBySubjectIdQueryHandler(
            IMapper mapper,
            IEntityMapperService<LectureResponseModel> entityMapperService,
            ISubjectService subjectService)
        {
            _mapper = mapper;
            _entityMapperService = entityMapperService;
            _subjectService = subjectService;
        }
        public async Task<SubjectLecturesResponseModel> Handle(GetLecturesBySubjectIdQuery request, CancellationToken cancellationToken)
        {
            if(!await _subjectService.IsExists(request.Id)) 
                throw new SubjectIdDoesNotExistsException(request.Id.ToString());

            var subject = await _subjectService.GetById(request.Id);
            
            var response = _mapper.Map<SubjectLecturesResponseModel>(subject);
            response.Lectures = await _entityMapperService.Map(response.Lectures);

            return response;
        }
    }
}