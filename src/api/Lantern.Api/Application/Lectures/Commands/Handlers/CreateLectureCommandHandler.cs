using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Mappers.Services;
using Lantern.Core.Services.Lectures.Exceptions;
using Lantern.Core.Services.Subjects.Exceptions;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Lectures.Commands.Handlers
{
    public class CreateLectureCommandHandler : IRequestHandler<CreateLectureCommand, LectureResponseModel>
    {
        private readonly ILectureTheatreService _lectureTheatreService;
        private readonly IEntityMapperService<LectureResponseModel> _entityMapperService;
        private readonly IMapper _mapper;
        private readonly ISubjectService _subjectService;

        public CreateLectureCommandHandler(
            IMapper mapper,
            ISubjectService subjectService,
            ILectureTheatreService lectureTheatreService,
            IEntityMapperService<LectureResponseModel> entityMapperService)
        {
            _mapper = mapper;
            _subjectService = subjectService;
            _lectureTheatreService = lectureTheatreService;
            _entityMapperService = entityMapperService;
        }

        public async Task<LectureResponseModel> Handle(CreateLectureCommand request, CancellationToken cancellationToken)
        {
            if (!await _subjectService.IsExists(request.Id)) 
                throw new SubjectIdDoesNotExistsException(request.Id.ToString());

            if (!await _lectureTheatreService.IsExists(request.LectureTheatreId))
                throw new LectureTheatreIdDoesNotExistsException(request.LectureTheatreId.ToString());

            var subject = await _subjectService.GetById(request.Id);
            var lectureTheatreId = await _lectureTheatreService.GetById(request.LectureTheatreId);

            var lecture = subject.AddLecture(
                request.DayOfWeek,
                request.StartTime,
                request.EndTime,
                lectureTheatreId);

            await _subjectService.Save(subject);

            var response = _mapper.Map<LectureResponseModel>(lecture);

            return await _entityMapperService.Map(response);
        }
    }
}