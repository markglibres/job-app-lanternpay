using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Mappers.Services;
using Lantern.Api.Application.Subjects.ResponseModels;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using Lantern.Domain.Subjects;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries.Handlers
{
    public class GetSubjectsQueryHandler : IRequestHandler<GetSubjectsQuery, IEnumerable<SubjectResponseModel>>
    {
        private readonly IMapper _mapper;
        private readonly IEntityMapperService<SubjectResponseModel> _subjectMapperService;
        private readonly ISubjectService _subjectService;

        public GetSubjectsQueryHandler(
            IMapper mapper,
            IEntityMapperService<SubjectResponseModel> subjectMapperService,
            ISubjectService subjectService)
        {
            _mapper = mapper;
            _subjectMapperService = subjectMapperService;
            _subjectService = subjectService;
        }
        
        public async Task<IEnumerable<SubjectResponseModel>> Handle(GetSubjectsQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _subjectService.GetAll();

            var response = _mapper
                .Map<IEnumerable<SubjectResponseModel>>(subjects)
                .ToList();

            var mappedResponse = await _subjectMapperService.Map(response);
                
            return mappedResponse;
        }
    }
}