using FluentValidation;

namespace PatientNow.CleanArchTemplate.WebApi.Inputs.Validators
{
    public class PatientInfoInputValidator : AbstractValidator<PatientInfoInput>
    {
        public PatientInfoInputValidator()
        {
            RuleFor(x => x.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);

            RuleFor(x => x.Dob)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.Ethnicity)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Gender)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .MaximumLength(1);

            RuleFor(x => x.MiddleName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(x => x.Ssn)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .MaximumLength(12);

            RuleFor(x => x.MaritalStatus)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
            
            RuleFor(x => x.Race)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
            
            RuleFor(x => x.Religion)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50);
            
            RuleFor(x => x.PracticeId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
