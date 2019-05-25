using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Students.Queries
{
    public class GetEnrollmentsByStudentIdQuery : IRequest<GetEnrollmentsByStudentIdQueryModel>
    {
        [FromQuery] public Guid Id { get; set; }
    }
}