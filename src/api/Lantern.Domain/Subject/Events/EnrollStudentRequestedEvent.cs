using System;
using Lantern.Domain.Models;

namespace Lantern.Domain.Subject.Events
{
    public class EnrollStudentRequestedEvent : DomainEvent
    {
        public Guid SubjectId { get; }
        public Guid StudentId { get; }

        public EnrollStudentRequestedEvent(
            Guid subjectId, 
            Guid studentId)
        {
            Id = Guid.NewGuid();
            SubjectId = subjectId;
            StudentId = studentId;
        }
    }
}