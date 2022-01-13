using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientNow.CleanArchTemplate.Infrastructure.Data;
using PatientNow.CleanArchTemplate.Infrastructure.Services;
using PatientNow.CleanArchTemplate.SharedKernel.Interfaces;
using PatientNow.CleanArchTemplate.SharedKernel.Models;

namespace PatientNow.CleanArchTemplate.Infrastructure;

public static class DependenciesInjection
{
    public static void AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies()
            .Where(x => x.FullName.StartsWith("PatientNow.CleanArchTemplate"));

        services.Configure<AppConfig>(configuration.GetSection(nameof(AppConfig)));
        services.AddAutoMapper(assemblies);
        
        services.AddSqlServer<MyPatientNowContext>(configuration.GetConnectionString("patientPortalConnectionString"),
            options =>
            {
                options.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
            });

        //Services
        services.AddTransient<IPatientService, PatientService>();
    }
}