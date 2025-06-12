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
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;
        public SubscriptionRepository(ApplicationDbContext context)
            => _context = context;

        public async Task<IEnumerable<Subscription>> GetAllAsync()
            => await _context.Subscriptions.AsNoTracking().ToListAsync();

        public async Task<Subscription?> GetByIdAsync(Guid id)
            => await _context.Subscriptions.FindAsync(id);

        public async Task<IEnumerable<Subscription>> GetByUserIdAsync(Guid userId)
            => await _context.Subscriptions
                    .AsNoTracking()
                    .Where(s => s.UserId == userId)
                    .ToListAsync();

        public async Task<IEnumerable<Subscription>> GetActiveByUserIdAsync(Guid userId)
            => await _context.Subscriptions
                    .AsNoTracking()
                    .Where(s => s.UserId == userId && s.IsActive)
                    .ToListAsync();

        public async Task AddAsync(Subscription entity)
        {
            await _context.Subscriptions.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Subscription entity)
        {
            _context.Subscriptions.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Subscription entity)
        {
            _context.Subscriptions.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
