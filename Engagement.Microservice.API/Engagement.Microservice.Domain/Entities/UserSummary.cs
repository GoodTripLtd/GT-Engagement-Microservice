using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Domain.Entities
{
    public class UserSummary : BaseEntity
    {
        public string UserName { get; set; } = null!;
        public List<Follow> Followers { get; set; }
        public List<Subscription> Subscriptions { get; set; }
        public List<Follow> Following { get; set; }
        // навігаційні колекції тощо
    }
}
