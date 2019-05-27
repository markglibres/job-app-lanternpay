using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using MediatR;

namespace Lantern.Api.Application.Lectures.Queries.Handlers
{
    public class GetLectureTheatreByIdQueryHandler : IRequestHandler<GetLectureTheatreByIdQuery, LectureTheatreResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly ILectureTheatreService _lectureTheatreService;

        public GetLectureTheatreByIdQueryHandler(
            IMapper mapper,
            ILectureTheatreService lectureTheatreService)
        {
            _mapper = mapper;
            _lectureTheatreService = lectureTheatreService;
        }

        public async Task<LectureTheatreResponseModel> Handle(GetLectureTheatreByIdQuery request,
            CancellationToken cancellationToken)
        {
            var theatre = await _lectureTheatreService.GetById(request.Id);

            var response = _mapper.Map<LectureTheatreResponseModel>(theatre);
            
            return response;
        }
    }
}