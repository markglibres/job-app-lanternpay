using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Lantern.Api.Application.Lectures.Commands;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Api.Application.Students.Commands;
using Lantern.Api.Application.Subjects.Commands;
using Lantern.Api.Application.Subjects.Queries;
using Lantern.Api.Application.Subjects.ResponseModels;
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
        [ProducesResponseType(typeof(SubjectResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateSubjectCommand command)
        {
            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SubjectResponseModel>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetSubjectsQuery());
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(SubjectResponseModel),(int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetById([FromRoute] GetSubjectByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("{Id}/lectures")]
        [ProducesResponseType(typeof(LectureResponseModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> CreateLecture(Guid id, CreateLectureCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}/lectures")]
        [ProducesResponseType(typeof(SubjectLecturesResponseModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetLecturesBySubject(Guid id)
        {
            var result = await _mediator.Send(new GetLecturesBySubjectIdQuery { Id = id});
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}/students")]
        [ProducesResponseType(typeof(GetStudentsBySubjectIdQueryResponseModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetStudentsBySubject([FromRoute] GetStudentsBySubjectIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}