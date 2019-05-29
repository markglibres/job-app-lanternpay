using System;
using Lantern.Domain.SeedWork;
using MediatR;

namespace Lantern.Domain.Enrollments.Events
{
    public class EnrollmentApprovedEvent : DomainEvent
    {
        public EnrollmentApprovedEvent(Guid applicationId)
        {
            Id = Guid.NewGuid();
            ApplicationId = applicationId;
        }

        public Guid ApplicationId { get; }
    }
}