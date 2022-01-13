using AutoMapper;
using PatientNow.CleanArchTemplate.Core.Models;
using PatientNow.CleanArchTemplate.SharedKernel.Dtos;

namespace PatientNow.CleanArchTemplate.Infrastructure.Mappers;

public class DtoToEntitiesMapping : Profile
{
    public DtoToEntitiesMapping()
    {

        CreateMap<PatientBasicInfo, PatientDto>()
            .ForMember(p => p.MaritalStatus, opt => opt.MapFrom(x => x.Marital))
            .ForMember(p => p.SocialSecurityNumber, opt => opt.MapFrom(x => x.Ssn))
            .ForMember(p => p.FirstName, opt => opt.MapFrom(x => x.Fname))
            .ForMember(p => p.LastName, opt => opt.MapFrom(x => x.Lname))
            .ForMember(p => p.MiddleName, opt => opt.MapFrom(x => x.Mname))
            .ForMember(p => p.DateOfBirth,
                opt => opt.MapFrom(x =>
                    x.Dob == null ? null : x.Dob.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffffff'Z'")))
            .ForMember(p => p.IsPrimaryCareProvider, opt => opt.MapFrom(x => x.Isprimarycareprovider))
            .ForMember(p => p.HasPrimaryCareProvider, opt => opt.MapFrom(x => x.Hasprimarycareprovider))
            .ForMember(p => p.PrimaryCareProvider, opt => opt.MapFrom(x => x.PrimaryCareProvider))
            .ReverseMap();
    }
}