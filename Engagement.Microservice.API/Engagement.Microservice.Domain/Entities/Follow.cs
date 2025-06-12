using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Domain.Entities
{
    public class Follow
    {
        public Guid FollowerId { get; set; }
        public UserSummary Follower { get; set; } = null!;

        public Guid FollowedId { get; set; }
        public UserSummary Followed { get; set; } = null!;

        public DateTime FollowedAt { get; set; }
    }
}
