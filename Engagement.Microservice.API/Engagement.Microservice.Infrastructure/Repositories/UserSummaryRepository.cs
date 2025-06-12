using Engagement.Microservice.Common.Interfaces;
using Engagement.Microservice.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Infrastructure.Repositories
{
    public class UserSummaryRepository : IUserSummaryRepository
    {
        private readonly ApplicationDbContext _context;
        public UserSummaryRepository(ApplicationDbContext context)
            => _context = context;

        public async Task<IEnumerable<UserSummary>> GetAllAsync()
            => await _context.UserSummaries.AsNoTracking().ToListAsync();

        public async Task<UserSummary?> GetByIdAsync(Guid id)
            => await _context.UserSummaries.FindAsync(id);

        public async Task AddAsync(UserSummary entity)
        {
            await _context.UserSummaries.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserSummary entity)
        {
            _context.UserSummaries.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(UserSummary entity)
        {
            _context.UserSummaries.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
