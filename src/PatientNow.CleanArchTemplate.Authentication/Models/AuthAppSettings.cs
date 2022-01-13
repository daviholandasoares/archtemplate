namespace PatientNow.CleanArchTemplate.Authentication.Models;

public class AuthAppSettings
{
    public string AppClientId { get; set; }
    public string AccessKeyId { get; set; }
    public string AccessSecretKey { get; set; }
    public string UserPoolId { get; set; }
    public string Region { get; set; }
}