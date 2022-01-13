using System.Collections;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PatientNow.CleanArchTemplate.SharedKernel.Models;

namespace PatientNow.CleanArchTemplate.WebApi.Filters;

public class InputValidationActionFilter : IAsyncActionFilter
{
    private readonly IValidatorFactory _validatorFactory;

    public InputValidationActionFilter(IValidatorFactory validatorFactory)
        => _validatorFactory = validatorFactory;

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        List<string> erros = new List<string>();

        foreach ((string key, object? value) in context.ActionArguments)
        {
            if (value == null) continue;
            Type type = GetObjectType(value);
            
            var validator = _validatorFactory.GetValidator(type);

            if (validator == null)
                continue;

            foreach (object obj in GetObjects(value))
            {
               var result = await validator?.ValidateAsync(obj);

                if(result.IsValid) continue;

                erros.AddRange(result?.Errors.Select(x => x.ErrorMessage) ?? new List<string>());
            }
        }

        if (erros.Any())
            context.Result = new BadRequestObjectResult(new Error(string.Join(", ", erros), 4));
        else
            await next();
    }

    private Type GetObjectType(object value)
    {
        Type type = value.GetType();
        
        if (TypeIsEnumerable(type))
            return type.GenericTypeArguments[0];

        return type;
    }

    private IEnumerable<object> GetObjects(object value)
    {
        if (TypeIsEnumerable(value.GetType()))
            foreach (object? item in value as IEnumerable)
                yield return item;
        else
            yield return value;
    }

    private bool TypeIsEnumerable(Type type)
        => type.IsGenericType && typeof(IEnumerable).IsAssignableFrom(type);

    private string ErrorStringToJson(ref List<string> erros)
        => JsonSerializer.Serialize(erros);
}