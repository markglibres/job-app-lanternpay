using System;
using Lantern.Domain.Lectures;
using MediatR;

namespace Lantern.Api.Application.Lectures.Commands
{
    public class CreateLectureCommand : IRequest<Lecture>
    {
        public Guid SubjectId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid LectureTheatreId { get; set; }
        
    }
}