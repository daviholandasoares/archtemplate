using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PatientNow.CleanArchTemplate.Authentication.Interfaces;
using PatientNow.CleanArchTemplate.Authentication.Models;

namespace PatientNow.CleanArchTemplate.Authentication;

public static class IoC
{
    public static void AddPatientNowAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AuthAppSettings>(configuration.GetSection(nameof(AuthAppSettings)));

        services.AddScoped<IAuthProviderFactory, AuthProviderFactory>();
        services.AddScoped<IAuthUserFactory, AuthUserFactory>();

        //Facade Service
        services.AddTransient<IAuthenticationService, AuthenticationService>();
    }
}