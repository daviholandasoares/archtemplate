using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace PatientNow.CleanArchTemplate.WebApi.Configurations;

public static class AuthenticationConfig
{
    public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.MetadataAddress = configuration.GetValue<string>("Authentication:JwtBearer:MetadataAddress");
                options.SaveToken = configuration.GetValue<bool>("Authentication:JwtBearer:SaveToken");
                options.IncludeErrorDetails =
                    configuration.GetValue<bool>("Authentication:JwtBearer:IncludeErrorDetails");
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience =
                        configuration.GetValue<bool>(
                            "Authentication:JwtBearer:TokenValidationParameters:ValidateAudience"),
                    RoleClaimType =
                        configuration.GetValue<string>(
                            "Authentication:JwtBearer:TokenValidationParameters:RoleClaimType")
                };
            });
    }
}