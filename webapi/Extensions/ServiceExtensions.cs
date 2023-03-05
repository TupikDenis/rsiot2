using Microsoft.EntityFrameworkCore;
using webapi.Contracts.Repositories;
using webapi.Contracts.Services;
using webapi.Persistence;
using webapi.Persistence.Repositories;
using webapi.Services;

namespace webapi.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IMarkService, MarkService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddTransient<ISubService, SubService>();
            services.AddTransient<IPubService, PubService>();
        }

        public static void ConfigurePostgresConnection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
             opts.UseNpgsql(configuration.GetConnectionString("postgreConnection")));
        }

        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(opts =>
            {
                opts.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
    }
}
