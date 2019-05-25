using System;
using Lantern.Domain.Models;
using Lantern.Domain.SeedWork;

namespace Lantern.Domain.Enrollments.Events
{
    public class EnrollmentApprovedEvent : DomainEvent
    {
        public Guid EnrollmentId { get; }

        public EnrollmentApprovedEvent(Guid enrollmentId)
        {
            Id = Guid.NewGuid();
            EnrollmentId = enrollmentId;
        }
    }
}