using System;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Domain.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Students.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentResponseModel>
    {
        [FromRoute] public Guid Id { get; set; }
    }
}