using System;
using Lantern.Domain.SeedWork;
using Newtonsoft.Json;

namespace Lantern.Domain.Lectures
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

        public DayOfWeek DayOfWeek { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public Guid SubjectId  { get; private set; }
        public Guid LectureTheatreId  { get; private set; }
    }
}