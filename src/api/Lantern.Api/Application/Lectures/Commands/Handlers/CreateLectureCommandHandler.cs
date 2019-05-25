using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Commands.Handlers;
using Lantern.Api.Application.Lectures.Exceptions;
using Lantern.Domain.Lectures;
using Lantern.Domain.Lectures.Services;
using Lantern.Domain.Subjects.Services;
using MediatR;

namespace Lantern.Api.Application.Lectures.Commands.Handlers
{
    public class CreateLectureCommandHandler : IRequestHandler<CreateLectureCommand, Lecture>
    {
        private readonly ISubjectService _subjectService;
        private readonly ILectureTheatreService _lectureTheatreService;

        public CreateLectureCommandHandler(
            ISubjectService subjectService,
            ILectureTheatreService lectureTheatreService )
        {
            _subjectService = subjectService;
            _lectureTheatreService = lectureTheatreService;
        }
        
        public async Task<Lecture> Handle(CreateLectureCommand request, CancellationToken cancellationToken)
        {
            if(!await _subjectService.IsExists(request.Id)) throw new SubjectDoesNotExistsException();
            
            if(!await _lectureTheatreService.IsExists(request.LectureTheatreId)) throw new LectureTheatreDoesNotExistsException();

            var subject = await _subjectService.GetById(request.Id);
            var lectureTheatreId = await _lectureTheatreService.GetById(request.LectureTheatreId);
            
            var lecture = subject.AddLecture(
                request.DayOfWeek,
                request.StartTime,
                request.EndTime,
                lectureTheatreId);

            await _subjectService.Save(subject);

            return lecture;

        }
    }

    
}