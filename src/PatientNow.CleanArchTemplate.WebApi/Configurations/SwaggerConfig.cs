using System.Text.RegularExpressions;
using Microsoft.OpenApi.Models;

namespace PatientNow.CleanArchTemplate.WebApi.Configurations;

public static class SwaggerConfig
{
    public static void AddSwaggerConfig(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddSwaggerGen(options =>
        {
            //options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            //{
            //    Type = SecuritySchemeType.OAuth2,
            //    Flows = new OpenApiOAuthFlows
            //    {
            //        AuthorizationCode = new OpenApiOAuthFlow
            //        {
            //            AuthorizationUrl =
            //                new Uri(configuration.GetValue<string>("Authentication:OAuth2:AuthorizationUrl")),
            //            RefreshUrl = new Uri(configuration.GetValue<string>("Authentication:OAuth2:RefreshUrl")),
            //            TokenUrl = new Uri(configuration.GetValue<string>("Authentication:OAuth2:TokenUrl"))
            //        }
            //    }
            //});
            //options.AddSecurityRequirement(new OpenApiSecurityRequirement
            //{
            //    {
            //        new OpenApiSecurityScheme
            //        {
            //            Reference = new OpenApiReference
            //            {
            //                Type = ReferenceType.SecurityScheme,
            //                Id = "oauth2"
            //            }
            //        },
            //        Array.Empty<string>()
            //    }
            //});

            options.SwaggerDoc("api", new OpenApiInfo
            {
                Version = configuration.GetValue<string>("Model:Version"),
                Title = "PatientNow MyPatientNow",
                Description = GetSwaggerDocDescription(),
                Contact = new OpenApiContact
                {
                    Name = "PatientNow dev team",
                    Email = "dev@patientnow.com"
                }
            });
        });
    }

    private static string GetSwaggerDocDescription()
    {
        var description = @"
                <p>Useful resources:</p>
                <ul>
                    <li><a href='https://www.patientnow.com' target='_blank' rel='noopener noreferrer'>How to get access tokens programatically for this API</a></li>
                    <li><a href='https://www.patientnow.com' target='_blank' rel='noopener noreferrer'>PatientNOW's company website</a></li>
                </ul>
                ";

        var cleanDescription = Regex.Replace(description, @"\s*(?<capture><(?<markUp>\w+)>.*<\/\k<markUp>>)\s*",
            "${capture}", RegexOptions.Singleline);
        return cleanDescription;
    }
}