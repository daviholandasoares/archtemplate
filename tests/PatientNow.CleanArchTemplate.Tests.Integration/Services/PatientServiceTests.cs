#region

using System;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using PatientNow.CleanArchTemplate.Infrastructure.Mappers;
using PatientNow.CleanArchTemplate.Infrastructure.Services;
using PatientNow.CleanArchTemplate.SharedKernel.Dtos;
using PatientNow.CleanArchTemplate.SharedKernel.Interfaces;
using PatientNow.CleanArchTemplate.Tests.Integration.Fixtures;
using PatientNow.CleanArchTemplate.Tests.Integration.Utilities.Seeds;
using Xunit;

#endregion

namespace PatientNow.CleanArchTemplate.Tests.Integration.Services;

[Collection("Test 2")]
public class PatientServiceTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _databaseFixture;
    private readonly IPatientService _patientService;

    public PatientServiceTests(DatabaseFixture databaseFixture)
    {
        _databaseFixture = databaseFixture;
        _patientService = new PatientService(databaseFixture.Context, CreateMapper());
    }


    [Fact(DisplayName = "Should return a PatientDto got by PatientId.")]
    public async Task GetPatientInformation_PatientId_ReturnsPatientDto()
    {
        //Arrange
        var patientId = 1;
        await PatientBasicInfoSeed.SeedPatients(_databaseFixture.Context);

        //Act
        var patientDto = await _patientService.GetPatientInformation(patientId);

        //Assert
        patientDto.IsSuccess.Should().BeTrue();
        patientDto.Value.FirstName.Should().NotBeEmpty();
    }

    [Fact(DisplayName = "Should return a result with success and PatientDto when register on database.")]
    public async Task PostPatientInformation_PatientDto_ReturnsSuccessAndPatientDto()
    {
        //Arrange
        PatientDto patientDto = new()
        {
            FirstName = "Patient",
            MiddleName = "First",
            LastName = "Test",
            DateOfBirth = DateTime.UtcNow,
            SocialSecurityNumber = "22851985",
            ReferringProvider = ""
        };

        //Act
        var result = await _patientService.PostPatientInformation(patientDto);

        var patientBasicInFo =
            await _databaseFixture.Context.PatientBasicInfos.FirstOrDefaultAsync(x =>
                x.Ssn.Equals(patientDto.SocialSecurityNumber));

        //Assert
        result.IsSuccess.Should().BeTrue();
        patientBasicInFo.Mname.Should().Be(patientDto.MiddleName);
    }

    private IMapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile(new DtoToEntitiesMapping()));
        return config.CreateMapper();
    }
}