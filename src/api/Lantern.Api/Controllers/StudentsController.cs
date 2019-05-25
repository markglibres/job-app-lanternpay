using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Lantern.Api.Application.Students.Commands;
using Lantern.Api.Application.Students.Queries;
using Lantern.Domain.Students;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Controllers
{
    [Route("students")]
    [ApiController]
    public class StudentsController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(Student), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateStudentCommand command)
        {
            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Student>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll(GetStudentsQuery query)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Student),(int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(GetStudentByIdQuery query)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}/enrollments")]
        [ProducesResponseType(typeof(GetEnrollmentsByStudentIdQueryModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetEnrollmentsByStudent(GetEnrollmentsByStudentIdQuery query)
        {
            return Ok();
        }
        
    }
}