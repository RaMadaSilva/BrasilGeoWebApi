using BrasilGeo.Aplications.Adapter;
using BrasilGeo.Aplications.Commands.UserCommands;
using BrasilGeo.Aplications.Dtos;
using BrasilGeo.Aplications.Handlers.LocationIBGEHandler;
using BrasilGeo.Aplications.Handlers.UserHandler;
using BrasilGeo.Aplications.Services;
using BrasilGeo.Domain.Entities;
using BrasilGeo.Domain.Entities.IBGE;
using BrasilGeo.Domain.Interfaces.Adapter;
using BrasilGeo.Domain.Interfaces.Repositories;
using BrasilGeo.Domain.Interfaces.Services;
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
            services.AddScoped<IAdapter<User, UserDto>, UserToDtoAdapter>();
            services.AddScoped<IAdapter<IEnumerable<User>, IEnumerable<UserDto>>, UserDtoToListAdapter>();
            services.AddScoped<IAdapter<LocationIBGE, LocationIBGEDto>, LocationIBGEToDtoAdapter>();
            services.AddScoped<IAdapter<IEnumerable<LocationIBGE>, IEnumerable<LocationIBGEDto>>, LocationsToLocationsDtosListAdapter>();
            services.AddScoped<LoginHandler>();
            services.AddScoped<CreateUserHandler>();
            services.AddScoped<DeleteuserHandler>();
            services.AddScoped<UpdateUserHandler>();
            services.AddScoped<UserQueryHandler>();
            services.AddScoped<CreateLocationIBGEHandler>();
            services.AddScoped<UpdateLocationIBGEHandler>();
            services.AddScoped<DeleteLocationIBGEHandler>();
            services.AddScoped<LocationIBGECodeQueryHandler>();
            services.AddScoped<LocationIBGEStateQueryHandler>();
            services.AddScoped<LocationIBGECityQueryHandler>();
            services.AddScoped<LocationIBGEWithParameterQueryHandler>();





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
