using System;
using Lantern.Api.Application.Enrollments.ResponseModels;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Commands
{
    public class CreateEnrollmentCommand : IRequest<CreateEnrollmentResponseModel>
    {
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
    }
}