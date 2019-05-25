using System;
using MediatR;

namespace Lantern.Api.Application.Students.Queries
{
    public class GetEnrollmentsByStudentIdQuery : IRequest<GetEnrollmentsByStudentIdQueryModel>
    {
        public Guid StudentId { get; set; }
    }
}