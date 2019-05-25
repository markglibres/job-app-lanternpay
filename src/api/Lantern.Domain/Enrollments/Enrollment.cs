using System;
using Lantern.Domain.Enrollments.Events;
using Lantern.Domain.SeedWork;
using Newtonsoft.Json;

namespace Lantern.Domain.Enrollments
{
    public class Enrollment : AggregateRoot
    {
        [JsonConstructor]
        private Enrollment()
        {
        }

        public Enrollment(
            Guid applicationId,
            Guid subjectId,
            Guid studentId)
        {
            ApplicationId = applicationId;
            SubjectId = subjectId;
            StudentId = studentId;
            Id = Guid.NewGuid();
            Status = EnrollmentStatus.Pending;
            RejectReason = EnrollmentRejectReason.NotApplicable;

        }

        public Guid ApplicationId { get; }
        public Guid SubjectId { get; }
        public Guid StudentId { get; }
        public EnrollmentStatus Status { get; private set; }
        public EnrollmentRejectReason RejectReason { get; private set; }

        public void Approve()
        {
            Status = EnrollmentStatus.Approved;
            Emit(new EnrollmentApprovedEvent(Id));
        }

        public void Reject(EnrollmentRejectReason reason)
        {
            Status = EnrollmentStatus.Error;
            RejectReason = reason;
        }
    }
}