using Engagement.Microservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Common.Interfaces
{
    public interface IFollowRepository
    {
        Task<IEnumerable<Follow>> GetAllAsync();
        Task<IEnumerable<Follow>> GetByFollowerIdAsync(Guid followerId);
        Task<IEnumerable<Follow>> GetByFollowedIdAsync(Guid followedId);
        Task AddAsync(Follow entity);
        Task RemoveAsync(Follow entity);
    }
}
