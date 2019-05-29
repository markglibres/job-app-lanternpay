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
    public class GetSubjectByIdQueryHandler : IRequestHandler<GetSubjectByIdQuery, SubjectResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;
        private readonly IEntityMapperService<LectureResponseModel> _entityMapperService;

        public GetSubjectByIdQueryHandler(
            IMapper mapper,
            ISubjectService subjectService,
            IEntityMapperService<LectureResponseModel> entityMapperService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
            _entityMapperService = entityMapperService;
        }
        
        public async Task<SubjectResponseModel> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            if(!await _subjectService.IsExists(request.Id)) 
                throw new SubjectIdDoesNotExistsException(request.Id.ToString());

            var subject = await _subjectService.GetById(request.Id);

            var response = _mapper.Map<SubjectResponseModel>(subject);

            var mappedLectures = await _entityMapperService.Map(response.Lectures);
            response.Lectures = mappedLectures;
            
            return response;
        }
    }
}