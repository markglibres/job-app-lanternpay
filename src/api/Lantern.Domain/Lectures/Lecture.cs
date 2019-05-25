using System;
using Lantern.Domain.SeedWork;
using Newtonsoft.Json;

namespace Lantern.Domain.Models
{
    public class Lecture : Entity
    {
        [JsonConstructor]
        private Lecture(){}
        
        public Lecture(
            Guid subjectId,
            Guid lectureTheatreId,
            DayOfWeek dayOfWeek,
            DateTime startTime,
            DateTime endTime)
        {
            Id = Guid.NewGuid();
            SubjectId = subjectId;
            DayOfWeek = dayOfWeek;
            StartTime = startTime;
            EndTime = endTime;
            LectureTheatreId = lectureTheatreId;
        }

        public DayOfWeek DayOfWeek { get; protected set; }
        public DateTime StartTime { get; protected set; }
        public DateTime EndTime { get; protected set; }
        public Guid SubjectId  { get; protected set; }
        public Guid LectureTheatreId  { get; protected set; }
    }
}