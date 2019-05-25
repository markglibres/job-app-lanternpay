using System;
using MediatR;

namespace Lantern.Api.Application.Enrollments.Commands
{
    public class CreateEnrollmentCommand : IRequest<Guid>
    {
        public Guid SubjectId { get; set; }
        public Guid StudentId { get; set; }
    }
}