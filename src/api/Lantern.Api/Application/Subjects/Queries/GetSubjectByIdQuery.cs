using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetSubjectByIdQuery : IRequest<Domain.Subjects.Subject>
    {
        [FromQuery]
        public Guid Id { get; set; }
    }
}