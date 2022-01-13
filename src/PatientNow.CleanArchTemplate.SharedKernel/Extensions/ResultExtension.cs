using CSharpFunctionalExtensions;
using PatientNow.CleanArchTemplate.SharedKernel.Models;

namespace PatientNow.CleanArchTemplate.SharedKernel.Extensions;

public static class ResultExtension
{
    public static Result SendError<T>(this Result result,
        Error values)
        => result.OnFailure(x => values.ToString());

}