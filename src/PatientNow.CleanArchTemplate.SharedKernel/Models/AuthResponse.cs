namespace PatientNow.CleanArchTemplate.SharedKernel.Models;

public struct AuthResponse
{
    public string EmailAddress { get; set; }
    public string UserId { get; set; }
    public string Token { get; set; }
}