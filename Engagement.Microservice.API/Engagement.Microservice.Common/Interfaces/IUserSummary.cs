using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Common.Interfaces
{
    public interface IUserSummaryRepository
    {
        Task<IEnumerable<UserSummary>> GetAllAsync();
        Task<UserSummary?> GetByIdAsync(Guid id);
        Task AddAsync(UserSummary entity);
        Task UpdateAsync(UserSummary entity);
        Task RemoveAsync(UserSummary entity);
    }
}
