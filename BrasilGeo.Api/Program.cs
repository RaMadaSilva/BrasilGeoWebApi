using BrasilGeo.Api.Extensions;
using BrasilGeo.Infra.Context;
using BrasilGeo.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddSwaggerExtensions();
builder.Services.AddApplicationServices(configuration); 
builder.Services.AddEndpointsApiExplorer();



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
        options.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

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
