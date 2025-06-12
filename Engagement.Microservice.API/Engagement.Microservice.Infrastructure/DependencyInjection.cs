using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engagement.Microservice.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IPlaceTagRepository, PlaceTagRepository>();
            services.AddScoped<IReplyRepository, ReplyRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserSummaryRepository, UserSummaryRepository>();
            services.AddScoped<IVoteRepository, VoteRepository>();

            return services;
        }
    }
}
