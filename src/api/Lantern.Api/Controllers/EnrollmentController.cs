using System.Net;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Commands;
using Lantern.Domain.Enrollments;
using Lantern.Domain.Enrollments.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Lantern.Api.Controllers
{
    [Route("enrollments")]
    [ApiController]
    public class EnrollmentController : Controller
    {
        private readonly Mediator _mediator;

        public EnrollmentController(
            Mediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(CreateEnrollmentCommandModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Enroll([FromBody] CreateEnrollmentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}