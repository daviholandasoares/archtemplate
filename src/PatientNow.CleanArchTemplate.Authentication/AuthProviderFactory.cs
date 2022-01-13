using PatientNow.CleanArchTemplate.Authentication.Interfaces;
using PatientNow.CleanArchTemplate.Authentication.Models;

namespace PatientNow.CleanArchTemplate.Authentication;

internal class AuthProviderFactory : IAuthProviderFactory
{
    public object CreateProvider(ref AuthAppSettings settings)
    {
        throw new NotImplementedException();
    }
}