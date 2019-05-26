using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Lantern.Api.Application.Lectures.Commands;
using Lantern.Api.Application.Lectures.Queries;
using Lantern.Api.Application.Subjects.Commands;
using Lantern.Domain.Lectures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Controllers
{
    [Route("lecturetheatres")]
    [ApiController]
    public class LectureTheatresController : Controller
    {
        private readonly IMediator _mediator;

        public LectureTheatresController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(LectureTheatre), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateLectureTheatreCommand command)
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<LectureTheatre>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetLectureTheatresQuery());
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(LectureTheatre),(int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(GetLectureTheatreByIdQuery query)
        {
            return Ok();
        }
    }
}