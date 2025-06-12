using MediatR;
using Microsoft.AspNetCore.Mvc;
using Engagement.Microservice.Domain.Entities;
using Engagement.Microservice.AppCore.Queries;
using Engagement.Microservice.AppCore.Commands;

namespace Engagement.Microservice.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class SubscriptionController : BaseController
    {
        public SubscriptionController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetAll()
            => Ok(await _mediator.Send(new GetAllSubscriptionsQuery()));

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Subscription>> GetById(Guid id)
        {
            var sub = await _mediator.Send(new GetSubscriptionByIdQuery { Id = id });
            return sub is null ? NotFound() : Ok(sub);
        }

        [HttpGet("{userId:guid}")]
        public async Task<ActionResult<IEnumerable<Subscription>>> GetByUser(Guid userId)
            => Ok(await _mediator.Send(new GetSubscriptionsByUserQuery { UserId = userId }));

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateSubscriptionCommand cmd)
        {
            var id = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateSubscriptionCommand cmd)
        {
            var ok = await _mediator.Send(cmd);
            return ok ? NoContent() : NotFound();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ok = await _mediator.Send(new DeleteSubscriptionCommand { Id = id });
            return ok ? NoContent() : NotFound();
        }
    }
}
