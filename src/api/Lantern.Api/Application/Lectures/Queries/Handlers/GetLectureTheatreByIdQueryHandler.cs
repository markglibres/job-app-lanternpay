using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Lectures.Exceptions;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using MediatR;

namespace Lantern.Api.Application.Lectures.Queries.Handlers
{
    public class GetLectureTheatreByIdQueryHandler : IRequestHandler<GetLectureTheatreByIdQuery, LectureTheatre>
    {
        private readonly ILectureTheatreService _lectureTheatreService;

        public GetLectureTheatreByIdQueryHandler(ILectureTheatreService lectureTheatreService)
        {
            _lectureTheatreService = lectureTheatreService;
        }
        
        public async Task<LectureTheatre> Handle(GetLectureTheatreByIdQuery request, CancellationToken cancellationToken)
        {
            if(!await _lectureTheatreService.IsExists(request.Id)) throw new LectureTheatreDoesNotExistsException();

            var theatre = await _lectureTheatreService.GetById(request.Id);

            return theatre;
        }
    }
}