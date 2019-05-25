using System;
using Lantern.Domain.SeedWork;
using MediatR;

namespace Lantern.Domain.Subjects.Events
{
    public class EnrollStudentRequestedEvent : DomainEvent, INotification
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

        public Guid EnrollmentId => Id;
    }
}