using AutoMapper;
using Lantern.Api.Application.Enrollments.ResponseModels;
using Lantern.Domain.Enrollments;

namespace Lantern.Api.Application.Mappers.Converters
{
    public class EnrollmentToResponseModelConverter : ITypeConverter<Enrollment, EnrollmentResponseModel>
    {
        public EnrollmentResponseModel Convert(Enrollment source, EnrollmentResponseModel destination, ResolutionContext context)
        {
            return new EnrollmentResponseModel
            {
                ApplicationId = source.ApplicationId,
                RejectReason = source.RejectReason == EnrollmentRejectReason.NotApplicable
                    ? ""
                    : source.RejectReason.ToString(),
                Status = source.Status.ToString()
            };
        }
    }
}