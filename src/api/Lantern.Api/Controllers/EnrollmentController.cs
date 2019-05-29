using System.Net;
using System.Threading.Tasks;
using Lantern.Api.Application.Enrollments.Commands;
using Lantern.Api.Application.Enrollments.ResponseModels;
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
        private readonly IMediator _mediator;

        public EnrollmentController(
            IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(CreateEnrollmentResponseModel), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> Enroll([FromBody] CreateEnrollmentCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}