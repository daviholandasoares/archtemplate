namespace PatientNow.CleanArchTemplate.SharedKernel.Models;
public readonly record struct Error
{
    public string Message { get; init; }
    private readonly ErrorType _errorType;
    public string Type { get; init; }

    public Error(string message, int errorType)
    {
       Message = message;
       _errorType = (ErrorType)errorType;
       Type = _errorType.ToString();
    }

   public static implicit operator Error((string messageError, int errorType) values)
       => new Error(values.messageError, values.errorType);
}

public enum ErrorType
{
    NotFound = 1,
    Warning,
    Exception,
    Validation
}