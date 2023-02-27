using Microsoft.EntityFrameworkCore;
using webapi.BackgroundServices;
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
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddTransient<ISubService, SubService>();
            services.AddTransient<IPubService, PubService>();

            services.AddHostedService<SubscriberBackgroundService>();
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
