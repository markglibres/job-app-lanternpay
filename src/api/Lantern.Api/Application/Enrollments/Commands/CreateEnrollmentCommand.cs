using System;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Commands
{
    public class CreateEnrollmentCommand : IRequest<CreateEnrollmentCommandModel>
    {
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
    }
}