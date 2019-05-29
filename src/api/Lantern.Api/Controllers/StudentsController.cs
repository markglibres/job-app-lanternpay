using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Lantern.Api.Application.Students.Commands;
using Lantern.Api.Application.Students.Queries;
using Lantern.Api.Application.Students.ResponseModels;
using Lantern.Domain.Students;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Controllers
{
    [Route("students")]
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IMediator _mediator;


        public StudentsController(
            IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(StudentResponseModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StudentResponseModel>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetStudentsQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}")]
        [ProducesResponseType(typeof(StudentResponseModel),(int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetById([FromRoute] GetStudentByIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{Id}/enrollments")]
        [ProducesResponseType(typeof(GetEnrollmentsByStudentIdQueryResponseModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetEnrollmentsByStudent([FromRoute] GetEnrollmentsByStudentIdQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        
    }
}