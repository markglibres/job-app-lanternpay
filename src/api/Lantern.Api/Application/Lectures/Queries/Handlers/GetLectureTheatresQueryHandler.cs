using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using MediatR;

namespace Lantern.Api.Application.Lectures.Queries.Handlers
{
    public class GetLectureTheatresQueryHandler : IRequestHandler<GetLectureTheatresQuery, IEnumerable<LectureTheatreResponseModel>>
    {
        private readonly IMapper _mapper;
        private readonly ILectureTheatreService _lectureTheatreService;

        public GetLectureTheatresQueryHandler(
            IMapper mapper,
            ILectureTheatreService lectureTheatreService)
        {
            _mapper = mapper;
            _lectureTheatreService = lectureTheatreService;
        }
        public async Task<IEnumerable<LectureTheatreResponseModel>> Handle(GetLectureTheatresQuery request, CancellationToken cancellationToken)
        {
            var theatres = await _lectureTheatreService.GetAll();

            var response = _mapper.Map<IEnumerable<LectureTheatreResponseModel>>(theatres);

            return response;
        }
    }
}