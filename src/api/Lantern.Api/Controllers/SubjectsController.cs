using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Lantern.Api.Application.Lectures.Commands;
using Lantern.Api.Application.Students.Commands;
using Lantern.Api.Application.Subjects.Commands;
using Lantern.Api.Application.Subjects.Queries;
using Lantern.Domain.Lectures;
using Lantern.Domain.Students;
using Lantern.Domain.Subjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Controllers
{
    [Route("subjects")]
    [ApiController]
    public class SubjectsController : Controller
    {
        private readonly IMediator _mediator;

        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Subject), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateSubjectCommand command)
        {
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Subject>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(GetSubjectsQuery query)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Subject),(int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(GetSubjectByIdQuery query)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{id}/lectures")]
        [ProducesResponseType(typeof(Lecture), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> CreateLecture(CreateLectureCommand command)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/lectures")]
        [ProducesResponseType(typeof(GetLecturesBySubjectIdQueryModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetLecturesBySubject(GetLecturesBySubjectIdQuery query)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/students")]
        [ProducesResponseType(typeof(GetStudentsBySubjectIdQueryModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetStudentsBySubject(GetStudentsBySubjectIdQuery query)
        {
            return Ok();
        }
    }
}