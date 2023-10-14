using BrasilGeo.Domain.Repositories;
using BrasilGeo.Infra.Context;
using BrasilGeo.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;



namespace BrasilGeo.Infra.IoC
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ILocationIBGERepository, LocationIBGERepository>();
            services.AddScoped<IUserRepository, UserRepostitory>();

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddDbContext<BrazilGeoContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            });

            services.AddEndpointsApiExplorer();

         
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(configuration["Cors:ClientUri"]);
                });
            });

            return services;
        }
    }
}
