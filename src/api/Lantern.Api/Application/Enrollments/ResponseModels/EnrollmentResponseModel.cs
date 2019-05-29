using System;

namespace Lantern.Api.Application.Enrollments.ResponseModels
{
    public class EnrollmentResponseModel
    {
        public Guid ApplicationId { get; set; }
        public EnrollmentStudentResponseModel Student { get; set; }
        public EnrollmentSubjectResponseModel Subject { get; set; }
        public string Status { get; set; }
        public string RejectReason { get; set; }
    }
}