using Engagement.Microservice.AppCore.Commands;
using Engagement.Microservice.AppCore.Queries;
using Engagement.Microservice.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Engagement.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserSummaryController : BaseController
    {
        public UserSummaryController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSummary>>> GetAll()
            => Ok(await _mediator.Send(new GetAllUserSummariesQuery()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserSummary>> GetById(Guid id)
        {
            var user = await _mediator.Send(new GetUserSummaryByIdQuery { Id = id });
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateUserSummaryCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserSummaryCommand cmd)
        {
            var ok = await _mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _mediator.Send(new DeleteUserSummaryCommand { Id = id });
            return ok ? NoContent() : NotFound();
        }
    }
}
