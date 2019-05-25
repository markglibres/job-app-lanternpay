using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Lectures.Exceptions;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using MediatR;

namespace Lantern.Api.Application.Lectures.Commands.Handlers
{
    public class CreateLectureTheatreCommandHandler : IRequestHandler<CreateLectureTheatreCommand, LectureTheatre>
    {
        private readonly ILectureTheatreService _lectureTheatreService;

        public CreateLectureTheatreCommandHandler(ILectureTheatreService lectureTheatreService)
        {
            _lectureTheatreService = lectureTheatreService;
        }

        public async Task<LectureTheatre> Handle(CreateLectureTheatreCommand request,
            CancellationToken cancellationToken)
        {
            if (await _lectureTheatreService.IsExists(request.Name)) throw new LectureTheatreAlreadyExistsException(request.Name);

            var lectureTheatre = await _lectureTheatreService.Create(request.Name, request.Capacity);

            await _lectureTheatreService.Save(lectureTheatre);

            return lectureTheatre;
        }
    }
}