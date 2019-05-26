using System;
using Lantern.Domain.Lectures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Application.Lectures.Queries
{
    public class GetLectureTheatreByIdQuery : IRequest<LectureTheatre>
    {
        public Guid Id { get; set; }
    }
}