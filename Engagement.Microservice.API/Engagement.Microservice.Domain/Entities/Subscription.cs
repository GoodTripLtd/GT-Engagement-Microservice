using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Domain.Entities
{
    public class Subscription : BaseEntity
    {
        public Guid UserId { get; set; }
        public UserSummary User { get; set; } = null!;

        public string PlanName { get; set; } = null!;
        public DateTime StartedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public bool IsActive { get; set; }
    }
}
