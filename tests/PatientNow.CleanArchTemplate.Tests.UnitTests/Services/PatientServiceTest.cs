using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Moq.EntityFrameworkCore;
using PatientNow.CleanArchTemplate.Core.Models;
using PatientNow.CleanArchTemplate.Infrastructure.Data;
using PatientNow.CleanArchTemplate.Infrastructure.Mappers;
using PatientNow.CleanArchTemplate.Infrastructure.Services;
using PatientNow.CleanArchTemplate.SharedKernel.Dtos;
using PatientNow.CleanArchTemplate.SharedKernel.Interfaces;
using Xunit;

namespace PatientNow.CleanArchTemplate.Tests.UnitTests.Services
{
    public class PatientServiceTest
    {
        private readonly Mock<MyPatientNowContext> _contextMocked;
        private readonly IMapper _mapper;
        private readonly IPatientService _patientService;

        public PatientServiceTest()
        {
            _contextMocked = new Mock<MyPatientNowContext>();
            _mapper = CreateMapper();
            _patientService = new PatientService(_contextMocked.Object, _mapper);
        }

        [Fact(DisplayName = "Should return a PatientDto with fields FirstName filled.")]
        public async Task GetPatientInformation_MappingModelToDto_ReturnsPatientDtoCorresponding()
        {
            //Arrange
            var patientFakeId = 1;

            _contextMocked
                .Setup(x => x.PatientBasicInfos)
                .ReturnsDbSet(CreateSetOfPatient());

            //Act
            var patientMapped = await _patientService.GetPatientInformation(patientFakeId);

            //Assert
            patientMapped.IsSuccess.Should().BeTrue();
            patientMapped.Value
                .As<PatientDto>().FirstName.Should().Be("Patient");

        }


        private IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new DtoToEntitiesMapping()));
            return config.CreateMapper();
        }

        private IEnumerable<PatientBasicInfo> CreateSetOfPatient()
            => new List<PatientBasicInfo>
            {
                new PatientBasicInfo
                {
                    PatientId = 1,
                    Fname = "Patient",
                    Mname = "Test",
                    Dob = DateTime.Now,
                    Marital = "Yes",
                    FormerName = "Patient Test"
                },
                new PatientBasicInfo
                {
                    PatientId = 2,
                    Fname = "Patient",
                    Mname = "Test2",
                    Dob = DateTime.Now,
                    Marital = "Yes",
                    FormerName = "Patient Test2"
                }
            };
    }
}
