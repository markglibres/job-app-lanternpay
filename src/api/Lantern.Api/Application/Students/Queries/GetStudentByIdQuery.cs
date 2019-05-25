using System;
using Lantern.Domain.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Students.Queries
{
    public class GetStudentByIdQuery : IRequest<Student>
    {
        [FromQuery] public Guid Id { get; set; }
    }
}