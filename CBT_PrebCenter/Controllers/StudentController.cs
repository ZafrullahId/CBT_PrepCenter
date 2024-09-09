using Application.Features.Students.CreateStudent;
using Application.Features.Students.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CBT_PrepCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateStudentRequestModel model)
        {
            var tokenSource = new CancellationTokenSource();
            var command = new CreateStudentCommand(model);
            if(command == null) return BadRequest(model);
            var studentCommand  = await _mediator.Send(command, tokenSource.Token);
            return  Ok(studentCommand);



        }
    }
}
