using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using PatientNow.CleanArchTemplate.Core.Models;
using PatientNow.CleanArchTemplate.Infrastructure.Data;
using PatientNow.CleanArchTemplate.SharedKernel.Dtos;
using PatientNow.CleanArchTemplate.SharedKernel.Interfaces;
using PatientNow.CleanArchTemplate.SharedKernel.Models;

namespace PatientNow.CleanArchTemplate.Infrastructure.Services;

public class PatientService : IPatientService
{
    private readonly MyPatientNowContext _context;
    private readonly IMapper _mapper;

    public PatientService(MyPatientNowContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<PatientDto, Error>> GetPatientInformation(int patientId)
    {
        try
        {
            var patientInfo = await _context.PatientBasicInfos
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.PatientId == patientId);

            var tempReturn = _mapper.Map<PatientDto>(patientInfo);

            return Result.SuccessIf<PatientDto, Error>(tempReturn is { PatientId: > 0 }, tempReturn, ("Patient not found.", 1));
        }
        catch (Exception e)
        {
            return Result.Failure<PatientDto, Error>((e.Message, 3));
        }
       
    }


    public async Task<Result<PatientDto, Error>> PostPatientInformation(PatientDto patientInfo)
    {
        try
        {
            var tempReturn = _mapper.Map<PatientBasicInfo>(patientInfo);
            _context.PatientBasicInfos.Add(tempReturn);
            var created = await _context.SaveChangesAsync();

            patientInfo.PatientId = tempReturn.PatientId;

            return Result.SuccessIf<PatientDto, Error>(created != 0, patientInfo, ("Patient not created.", 1));
        }
        catch (Exception e)
        {
            return Result.Failure<PatientDto, Error>((e.Message, 3));
        }
        
    }
}