namespace PatientNow.CleanArchTemplate.WebApi.Inputs;

public record PatientInfoInput(
    string? FirstName = default,
    string? LastName = default,
    string? MiddleName = default,
    string? NickName = default,
    DateTime Dob = default,
    string? Ssn = default,
    string? Gender = default,
    string? MaritalStatus = default,
    string? Ethnicity = default,
    string? Race = default,
    string? Religion = default,
    string? PrimaryLanguage = default,
    bool? InterpreterRequired = default,
    bool? IsProviderReferred = default,
    string? ReferringProvider = default,
    bool? IsPrimaryCareProvider = default,
    bool? HasPrimaryCareProvider = default,
    string? PrimaryCareProvider = default,
    string? HearAboutUs = default,
    string? Email = default,
    string? Title = default,
    int? PracticeId = default);

