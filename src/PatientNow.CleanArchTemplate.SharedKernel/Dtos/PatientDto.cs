namespace PatientNow.CleanArchTemplate.SharedKernel.Dtos;

public struct PatientDto
{
    public int PatientId { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string Gender { get; set; }
    public string MaritalStatus { get; set; }
    public string Ethnicity { get; set; }
    public string Race { get; set; }
    public string Language { get; set; }
    public bool HasInterpreter { get; set; }
    public bool HasSpecificHealthCareProvider { get; set; }
    public string ReferringProvider { get; set; }
    public string Religion { get; set; }
    public string Nickname { get; set; }
    public string HeardAboutUs { get; set; }
    public int PracticeId { get; set; }
    public bool IsPrimaryCareProvider { get; set; }
    public bool HasPrimaryCareProvider { get; set; }
    public string PrimaryCareProvider { get; set; }
}