using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Common.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<Subscription?> GetByIdAsync(Guid id);
        Task<IEnumerable<Subscription>> GetByUserIdAsync(Guid userId);
        Task<IEnumerable<Subscription>> GetActiveByUserIdAsync(Guid userId);
        Task AddAsync(Subscription entity);
        Task UpdateAsync(Subscription entity);
        Task RemoveAsync(Subscription entity);
    }
}
