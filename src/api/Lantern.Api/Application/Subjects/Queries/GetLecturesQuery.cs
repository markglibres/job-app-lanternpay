using System;
using Lantern.Api.Application.Lectures.Queries;
using MediatR;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetLecturesQuery : IRequest<GetLecturesQueryModel>
    {
        public Guid SubjectId { get; set; }
    }
}