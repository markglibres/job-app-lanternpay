using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using MediatR;

namespace Lantern.Api.Application.Lectures.Queries.Handlers
{
    public class GetLectureTheatresQueryHandler : IRequestHandler<GetLectureTheatresQuery, IEnumerable<LectureTheatre>>
    {
        private readonly ILectureTheatreService _lectureTheatreService;

        public GetLectureTheatresQueryHandler(ILectureTheatreService lectureTheatreService)
        {
            _lectureTheatreService = lectureTheatreService;
        }
        public async Task<IEnumerable<LectureTheatre>> Handle(GetLectureTheatresQuery request, CancellationToken cancellationToken)
        {
            return await _lectureTheatreService.GetAll();
        }
    }
}