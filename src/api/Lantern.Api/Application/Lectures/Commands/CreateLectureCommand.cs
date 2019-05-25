using System;
using Lantern.Domain.Lectures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Lectures.Commands
{
    public class CreateLectureCommand : IRequest<Lecture>
    {
        [FromQuery]
        public Guid Id { get; set; }
        [FromBody]
        public DayOfWeek DayOfWeek { get; set; }
        [FromBody]
        public DateTime StartTime { get; set; }
        [FromBody]
        public DateTime EndTime { get; set; }
        [FromBody]
        public Guid LectureTheatreId { get; set; }
        
    }
}