using PatientNow.CleanArchTemplate.Authentication.Models;

namespace PatientNow.CleanArchTemplate.Authentication.Interfaces;

public interface IAuthProviderFactory
{
    object CreateProvider(ref AuthAppSettings settings);
}