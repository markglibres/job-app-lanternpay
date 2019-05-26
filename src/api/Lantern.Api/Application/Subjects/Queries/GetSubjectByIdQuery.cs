using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Subjects.Queries
{
    public class GetSubjectByIdQuery : IRequest<Domain.Subjects.Subject>
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}