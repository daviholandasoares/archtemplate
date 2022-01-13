namespace PatientNow.CleanArchTemplate.SharedKernel.Models;

public class AppConfig
{
    public string Environment { get; set; }
    public string Version { get; set; }

    public PatientNow PatientNow { get; set; }
}

public struct PatientNow
{
    public string Url { get; set; }
    public string Practice { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}