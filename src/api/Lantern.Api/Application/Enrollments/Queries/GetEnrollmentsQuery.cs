using System.Collections.Generic;
using Lantern.Api.Application.Enrollments.ResponseModels;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Queries
{
    public class GetEnrollmentsQuery : IRequest<IEnumerable<EnrollmentResponseModel>>
    {
        
    }
}