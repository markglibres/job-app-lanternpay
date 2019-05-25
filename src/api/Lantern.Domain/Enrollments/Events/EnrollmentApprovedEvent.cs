using System;
using Lantern.Domain.SeedWork;
using MediatR;

namespace Lantern.Domain.Enrollments.Events
{
    public class EnrollmentApprovedEvent : DomainEvent, INotification
    {
        public EnrollmentApprovedEvent(Guid enrollmentId)
        {
            Id = Guid.NewGuid();
            EnrollmentId = enrollmentId;
        }

        public Guid EnrollmentId { get; }
    }
}