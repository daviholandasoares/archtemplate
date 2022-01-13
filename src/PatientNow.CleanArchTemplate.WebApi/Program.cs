using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PatientNow.CleanArchTemplate.Authentication;
using PatientNow.CleanArchTemplate.Infrastructure;
using PatientNow.CleanArchTemplate.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Auth Configuration
builder.Services.AddAuthenticationConfig(builder.Configuration);

//Swagger Configuration
builder.Services.AddSwaggerConfig(builder.Configuration);

//Application services
builder.Services.AddInfrastructureDependencies(builder.Configuration);
builder.Services.AddPatientNowAuthentication(builder.Configuration);

//HealthChecks
builder.Services.AddHealthChecks()
    .AddSqlServer(builder.Configuration.GetConnectionString("patientPortalConnectionString"));

//Logging Service
builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = HttpLoggingFields.Request | HttpLoggingFields.Response;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
}

app.MapHealthChecks("/health", new HealthCheckOptions
{
    Predicate = _ => true,
    ResultStatusCodes =
    {
        [HealthStatus.Healthy ] = StatusCodes.Status200OK,
        [HealthStatus.Degraded] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    },
    ResponseWriter = async (context, report) =>
    {
        var result = JsonSerializer.Serialize(
            new
            {
                status = report.Status.ToString(),
                checks = report.Entries.Select(entry => new
                {
                    name = entry.Key,
                    status = entry.Value.Status.ToString(),
                    exception = entry.Value.Exception != null ? entry.Value.Exception.Message : "none",
                    duration = entry.Value.Duration.ToString()
                })
            }
        );

        context.Response.ContentType = MediaTypeNames.Application.Json;
        await context.Response.WriteAsync(result);
    }
});

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/api/swagger.json", "PatientNow MyPatientNow v1");
    //options.OAuthClientId(builder.Configuration.GetValue<string>("Authentication:OAuth2:ClientId"));
    //options.OAuthAppName(builder.Configuration.GetValue<string>("Authentication:OAuth2:AppName"));
    //options.OAuthUsePkce();
});

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors(option => option.AllowAnyOrigin());

app.Run();

//Just Integration Tests
namespace PatientNow.CleanArchTemplate.WebApi
{
    public partial class Program{}
}