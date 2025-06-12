using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.AppCore.Commands
{
    public class CreateFollowCommand : IRequest
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }
        public DateTime FollowedAt { get; set; }
    }

    public class DeleteFollowCommand : IRequest<bool>
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }
    }

    public class CreateSubscriptionCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string PlanName { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
    }

    public class UpdateSubscriptionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string PlanName { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
    }

    public class DeleteSubscriptionCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class CreateUserSummaryCommand : IRequest<Guid>
    {
        public string UserName { get; set; } = null!;
    }

    public class UpdateUserSummaryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
    }

    public class DeleteUserSummaryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
