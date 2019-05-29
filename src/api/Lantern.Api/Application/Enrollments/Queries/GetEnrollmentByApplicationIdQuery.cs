using System;
using Lantern.Api.Application.Enrollments.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Enrollments.Queries
{
    public class GetEnrollmentByApplicationIdQuery : IRequest<EnrollmentResponseModel>
    {
        [FromRoute] public Guid ApplicationId { get; set; }
    }
}