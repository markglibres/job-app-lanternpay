using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetStudentsBySubjectIdQuery : IRequest<GetStudentsBySubjectIdQueryModel>
    {
        [FromQuery] public Guid Id { get; set; }
    }
}