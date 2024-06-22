using Application.Command.StudentCommand.CreateStudent;
using Application.Dtos.RequestModel;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Register([FromBody] CreateStudentRequestModel model,CancellationToken  cancellationToken)
        {
            var command = new CreateStudentCommand(model);
            if(command == null) return BadRequest(model);
            var studentCommand  = await _mediator.Send(command, cancellationToken);
            return  Ok(studentCommand);



        }
    }
}
