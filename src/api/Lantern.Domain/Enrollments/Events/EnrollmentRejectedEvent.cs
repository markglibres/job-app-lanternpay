using System;
using Lantern.Domain.SeedWork;
using MediatR;

namespace Lantern.Domain.Enrollments.Events
{
    public class EnrollmentRejectedEvent: DomainEvent, INotification
    {
        public EnrollmentRejectedEvent(Guid enrollmentId)
        {
            Id = Guid.NewGuid();
            EnrollmentId = enrollmentId;
        }

        public Guid EnrollmentId { get; }
    }
}