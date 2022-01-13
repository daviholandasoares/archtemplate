using PatientNow.CleanArchTemplate.Authentication.Interfaces;
using PatientNow.CleanArchTemplate.Authentication.Models;

namespace PatientNow.CleanArchTemplate.Authentication;

internal class AuthUserFactory : IAuthUserFactory
{
    public object CreateProviderUser(IAuthProviderFactory providerFactory, ref AuthAppSettings settings, string userName)
    {
        throw new NotImplementedException();
    }
}