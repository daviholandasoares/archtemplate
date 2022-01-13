using PatientNow.CleanArchTemplate.Authentication.Models;

namespace PatientNow.CleanArchTemplate.Authentication.Interfaces;

public interface IAuthUserFactory
{
    object CreateProviderUser(IAuthProviderFactory providerFactory, ref AuthAppSettings settings, string userName);
}