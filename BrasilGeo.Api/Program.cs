using BrasilGeo.Api.Extensions;
using BrasilGeo.Infra.Context;
using BrasilGeo.Infra.IoC;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExtensions();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Secret"])),
        ValidateAudience = false,
        ValidateIssuer = false
    }; 
});
builder.Services.AddAuthorization(options=> {
    options.AddPolicy("RequireAdmin", policy => policy.RequireAssertion(context => context.User.HasClaim(c => c.Type == ClaimTypes.Name && c.Value == "Admin")));
    options.AddPolicy("RequireWrite", policy => policy.RequireClaim("Write"));
    options.AddPolicy("RequireReader", policy => policy.RequireClaim("Reader")); 
    }); 


builder.Services.AddApplicationServices(configuration); 

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = "index.html";
    });
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BrazilGeoContext>();
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        await context.Database.MigrateAsync();
    }
    catch (Exception exception)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(exception, "An error occured during migration");
    }
}

app.Run();
