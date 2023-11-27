using BallastLane.Business.Services;
using BallastLane.Infrastructure.Context;
using BallastLane.Infrastructure.Repositories;

namespace BallastLane.Api.Extensions
{
    public static class StartupExtensions
    {
        /// <summary>
        /// Injects the repositories
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INoteRepository, NoteRepository>();
        }

        /// <summary>
        /// Injects the services
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INoteService, NoteService>();
        }


        /// <summary>
        /// Configures the dbContext
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDbContext>();
            using (var provider = services.BuildServiceProvider())
            {
                var ctx = provider.GetService<ProjectDbContext>();
                if (ctx != null) ctx.Database.EnsureCreated();
            }
        }

    }
}
