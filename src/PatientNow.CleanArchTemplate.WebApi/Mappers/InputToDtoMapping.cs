using AutoMapper;
using PatientNow.CleanArchTemplate.SharedKernel.Dtos;
using PatientNow.CleanArchTemplate.WebApi.Inputs;

namespace PatientNow.CleanArchTemplate.WebApi.Mappers;
public class InputToDtoMapping : Profile
{
    public InputToDtoMapping()
    {
        CreateMap<PatientInfoInput, PatientDto>()
            .ForMember(p => p.HasSpecificHealthCareProvider, opt => opt.MapFrom(x => x.HasPrimaryCareProvider))
            .ForMember(p => p.SocialSecurityNumber, opt => opt.MapFrom(x => x.Ssn))
            .ForMember(p => p.Language, opt => opt.MapFrom(x => x.PrimaryLanguage))
            .ForMember(p => p.HasInterpreter, opt => opt.MapFrom(x => x.InterpreterRequired))
            .ForMember(p => p.DateOfBirth, opt => opt.MapFrom(x => x.Dob))
            .ForMember(p => p.SocialSecurityNumber, opt => opt.MapFrom(x => x.Ssn));

    }
}