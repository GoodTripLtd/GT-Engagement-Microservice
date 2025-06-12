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
    public class FollowRepository : IFollowRepository
    {
        private readonly ApplicationDbContext _context;
        public FollowRepository(ApplicationDbContext context)
            => _context = context;

        public async Task<IEnumerable<Follow>> GetAllAsync()
            => await _context.Follows.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Follow>> GetByFollowerIdAsync(Guid followerId)
            => await _context.Follows
                    .AsNoTracking()
                    .Where(f => f.FollowerId == followerId)
                    .ToListAsync();

        public async Task<IEnumerable<Follow>> GetByFollowedIdAsync(Guid followedId)
            => await _context.Follows
                    .AsNoTracking()
                    .Where(f => f.FollowedId == followedId)
                    .ToListAsync();

        public async Task AddAsync(Follow entity)
        {
            await _context.Follows.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Follow entity)
        {
            _context.Follows.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
