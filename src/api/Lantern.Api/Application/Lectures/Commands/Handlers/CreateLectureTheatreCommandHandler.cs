using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using MediatR;

namespace Lantern.Api.Application.Lectures.Commands.Handlers
{
    public class CreateLectureTheatreCommandHandler : IRequestHandler<CreateLectureTheatreCommand, LectureTheatreResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly ILectureTheatreService _lectureTheatreService;

        public CreateLectureTheatreCommandHandler(
            IMapper mapper,
            ILectureTheatreService lectureTheatreService)
        {
            _mapper = mapper;
            _lectureTheatreService = lectureTheatreService;
        }

        public async Task<LectureTheatreResponseModel> Handle(CreateLectureTheatreCommand request,
            CancellationToken cancellationToken)
        {
            var lectureTheatre = await _lectureTheatreService.Create(request.Name, request.Capacity);

            await _lectureTheatreService.Save(lectureTheatre);

            var response = _mapper.Map<LectureTheatreResponseModel>(lectureTheatre);
            
            return response;
        }
    }
}