using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientNow.CleanArchTemplate.SharedKernel.Dtos;
using PatientNow.CleanArchTemplate.SharedKernel.Interfaces;
using PatientNow.CleanArchTemplate.SharedKernel.Models;
using PatientNow.CleanArchTemplate.WebApi.Inputs;

namespace PatientNow.CleanArchTemplate.WebApi.Controllers;

[AllowAnonymous]
public class PatientController : BaseController
{
    private readonly IPatientService _patientService;
    private readonly IMapper _mapper;

    public PatientController(IPatientService patientService,
        IMapper mapper)
    {
        _patientService = patientService;
        _mapper = mapper;
    }

    [HttpGet("{patientId:int}", Name = "GetPatientInformation")]
    public async Task<IActionResult> GetPatientInformation(int patientId)
    {
        var result = await _patientService.GetPatientInformation(patientId);
        return CreateResponse(result);
    }

    [HttpPost("", Name = "PostPatientInformation")]
    public async Task<IActionResult> PostPatientInformation(PatientInfoInput patientInfoInput)
    {
        var tempInput = _mapper.Map<PatientDto>(patientInfoInput);
        var result = await _patientService.PostPatientInformation(tempInput);

        return CreateResponse(result);
    }
}