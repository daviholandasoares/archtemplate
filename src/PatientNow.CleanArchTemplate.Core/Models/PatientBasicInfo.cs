namespace PatientNow.CleanArchTemplate.Core.Models;

public class PatientBasicInfo
{
    public int PatientId { get; set; }
    public int? PracticeId { get; set; }
    public string? Fname { get; set; }
    public string? Lname { get; set; }
    public string? Mname { get; set; }
    public string? FormerName { get; set; }
    public string? NickName { get; set; }
    public string? Gender { get; set; }
    public DateTime? Dob { get; set; }
    public string? Title { get; set; }
    public string? Email { get; set; }
    public string? Ssn { get; set; }
    public string? Ethnicity { get; set; }
    public string? Race { get; set; }
    public string? Marital { get; set; }
    public string? Religion { get; set; }
    public string? Church { get; set; }
    public string? Language { get; set; }
    public bool? Interpreter { get; set; }
    public string? ReferringProvider { get; set; }
    public string? PrimaryCareProvider { get; set; }
    public string? ReferralSource { get; set; }
    public string? ReferralDetail { get; set; }
    public string? Pharmacy { get; set; }
    public int? HeightFeet { get; set; }
    public int? HeightInches { get; set; }
    public int? Weight { get; set; }
    public int PatientNowId { get; set; }
    public int EthnicId { get; set; }
    public bool? Specifichealthcareprovider { get; set; }
    public int Cotherproviderid { get; set; }
    public bool? Isprimarycareprovider { get; set; }
    public bool? Hasprimarycareprovider { get; set; }
    public int Cprimaryproviderid { get; set; }
    public int Refsourceid { get; set; }
    public string Refsourcedetail { get; set; } = string.Empty;
    public int Refsourceobjid { get; set; }
    public bool DoNotRequireEmailAuthentication { get; set; }
    public DateTime? DoNotRequireEmailAuthenticationDateTime { get; set; }
}