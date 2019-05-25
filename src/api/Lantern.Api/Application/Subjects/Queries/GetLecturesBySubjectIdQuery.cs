using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetLecturesBySubjectIdQuery : IRequest<GetLecturesBySubjectIdQueryModel>
    {
        [FromQuery] public Guid Id { get; set; }
    }
}