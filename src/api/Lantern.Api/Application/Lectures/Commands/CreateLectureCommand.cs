using System;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Lantern.Api.Application.Lectures.Commands
{
    public class CreateLectureCommand : IRequest<LectureResponseModel>
    {
        [JsonIgnore]
        [FromRoute]
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