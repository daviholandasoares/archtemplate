using CSharpFunctionalExtensions;
using PatientNow.CleanArchTemplate.SharedKernel.Dtos;
using PatientNow.CleanArchTemplate.SharedKernel.Models;

namespace PatientNow.CleanArchTemplate.SharedKernel.Interfaces;

public interface IPatientService
{
    Task<Result<PatientDto, Error>> GetPatientInformation(int patientId);
    Task<Result<PatientDto, Error>> PostPatientInformation(PatientDto patientDto);
}