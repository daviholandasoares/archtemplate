namespace PatientNow.CleanArchTemplate.Authentication.Models;

public record CreateUserInput(string Username, string Email, string PhoneNumber);

public record UserCredentialsInput(string Username, string Password);

public record Token(string Value);