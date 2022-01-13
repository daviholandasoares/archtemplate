using CSharpFunctionalExtensions;
using Microsoft.Extensions.Options;
using PatientNow.CleanArchTemplate.Authentication.Interfaces;
using PatientNow.CleanArchTemplate.Authentication.Models;

namespace PatientNow.CleanArchTemplate.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IAuthProviderFactory _authProviderFactory;
    private readonly IAuthUserFactory _userFactory;
    private AuthAppSettings _appSettings;

    public AuthenticationService(IAuthProviderFactory authProviderFactory, IAuthUserFactory userFactory,
        IOptions<AuthAppSettings> appSettings)
    {
        _authProviderFactory = authProviderFactory;
        _userFactory = userFactory;
        _appSettings = appSettings.Value;
    }

    public virtual Task<Result> CreateUser(CreateUserInput createUserInput)
    {
        throw new NotImplementedException();
    }

    public virtual Task<Result> UpdatePassword(UserCredentialsInput userCredentialsInput)
    {
        throw new NotImplementedException();
    }

    public virtual  Task<Result<Token>> GenerateTokenWithUserCredentials(UserCredentialsInput userCredentialsInput)
    {
        throw new NotImplementedException();
    }
}