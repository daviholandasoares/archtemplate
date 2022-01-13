using FluentValidation;
using FluentValidation.AspNetCore;
using PatientNow.CleanArchTemplate.WebApi.Filters;
using PatientNow.CleanArchTemplate.WebApi.Inputs;
using PatientNow.CleanArchTemplate.WebApi.Inputs.Validators;

namespace PatientNow.CleanArchTemplate.WebApi.Configurations;

public static class InputsValidationSetup
{
    public static void AddFluentValidation(this IMvcBuilder builder)
    {
        builder.Services.AddScoped<IValidatorFactory, ServiceProviderValidatorFactory>();
        //Registration of Validators
        builder.Services.AddScoped<IValidator<PatientInfoInput>, PatientInfoInputValidator>();

        builder.AddMvcOptions(options =>
        {
            options.Filters.Add<InputValidationActionFilter>();
        });
    }
}