using Engagement.Microservice.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.AppCore.Queries
{
    public class GetAllFollowsQuery : IRequest<IEnumerable<Follow>> { }

    public class GetFollowByIdsQuery : IRequest<Follow?>
    {
        public Guid FollowerId { get; set; }
        public Guid FollowedId { get; set; }
    }

    public class GetAllSubscriptionsQuery : IRequest<IEnumerable<Subscription>> { }

    public class GetSubscriptionByIdQuery : IRequest<Subscription?>
    {
        public Guid Id { get; set; }
    }

    public class GetSubscriptionsByUserQuery : IRequest<IEnumerable<Subscription>>
    {
        public Guid UserId { get; set; }
    }

    public class GetAllUserSummariesQuery : IRequest<IEnumerable<UserSummary>> { }

    public class GetUserSummaryByIdQuery : IRequest<UserSummary?>
    {
        public Guid Id { get; set; }
    }
}
