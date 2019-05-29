using System;
using Lantern.Api.Application.Students.ResponseModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Students.Queries
{
    public class GetEnrollmentsByStudentIdQuery : IRequest<GetEnrollmentsByStudentIdQueryResponseModel>
    {
        [FromRoute] public Guid Id { get; set; }
    }
}