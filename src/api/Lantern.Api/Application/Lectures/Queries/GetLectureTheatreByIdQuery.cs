using System;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Lectures.Queries
{
    public class GetLectureTheatreByIdQuery : IRequest<LectureTheatreResponseModel>
    {
        [FromRoute]
        public Guid Id { get; set; }
    }
}