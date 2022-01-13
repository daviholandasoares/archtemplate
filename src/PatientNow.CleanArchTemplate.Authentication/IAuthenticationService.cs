using CSharpFunctionalExtensions;
using PatientNow.CleanArchTemplate.Authentication.Models;

namespace PatientNow.CleanArchTemplate.Authentication;

public interface IAuthenticationService
{
    Task<Result> CreateUser(CreateUserInput createUserInput);
    Task<Result> UpdatePassword(UserCredentialsInput userCredentialsInput);
    Task<Result<Token>> GenerateTokenWithUserCredentials(UserCredentialsInput userCredentialsInput);
}