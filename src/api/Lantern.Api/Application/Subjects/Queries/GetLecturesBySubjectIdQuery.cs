using System;
using Lantern.Api.Application.Subjects.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetLecturesBySubjectIdQuery : IRequest<SubjectLecturesResponseModel>
    {
        [FromQuery] public Guid Id { get; set; }
    }
}