using BrasilGeo.Aplications.Adapter;
using BrasilGeo.Aplications.Commands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Handlers;
using BrasilGeo.Aplications.Services;
using BrasilGeo.Domain.Adapter;
using BrasilGeo.Domain.Repositories;
using BrasilGeo.Domain.Services;
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
            services.AddScoped<IUniteOfWork, UniteOfWork>();
            services.AddScoped<ILocationIBGERepository, LocationIBGERepository>();
            services.AddScoped<IUserRepository, UserRepostitory>();
            services.AddScoped<IGeneratorTokenService, GeneratorTokenService>(); 
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAdapter<LoginCommand, LoginDto>, LoginToDtoAdaoterAdapter>(); 
            services.AddScoped<LoginHandler>();
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<DeleteuserHandler >();
            services.AddScoped<UpdateUserHandler >();
            services.AddScoped<UserQueryHandler >();


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
