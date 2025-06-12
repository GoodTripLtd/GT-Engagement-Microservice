using MediatR;
using Microsoft.AspNetCore.Mvc;
using Engagement.Microservice.Domain.Entities;
using Engagement.Microservice.AppCore.Queries;
using Engagement.Microservice.AppCore.Commands;

namespace Engagement.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class FollowController : BaseController
    {
        public FollowController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Follow>>> GetAll()
            => Ok(await _mediator.Send(new GetAllFollowsQuery()));

        [HttpGet("{followerId:guid}/{followedId:guid}")]
        public async Task<ActionResult<Follow>> GetByIds(Guid followerId, Guid followedId)
        {
            var follow = await _mediator.Send(new GetFollowByIdsQuery { FollowerId = followerId, FollowedId = followedId });
            return follow is null ? NotFound() : Ok(follow);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateFollowCommand cmd)
        {
            await _mediator.Send(cmd);
            return NoContent();
        }

        [HttpDelete("{followerId:guid}/{followedId:guid}")]
        public async Task<IActionResult> Delete(Guid followerId, Guid followedId)
        {
            var ok = await _mediator.Send(new DeleteFollowCommand { FollowerId = followerId, FollowedId = followedId });
            return ok ? NoContent() : NotFound();
        }
    }
}
