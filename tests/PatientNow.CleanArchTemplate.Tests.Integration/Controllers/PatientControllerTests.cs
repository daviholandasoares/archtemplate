#region

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using FluentAssertions;
using PatientNow.CleanArchTemplate.SharedKernel.Dtos;
using PatientNow.CleanArchTemplate.Tests.Integration.Fixtures;
using PatientNow.CleanArchTemplate.WebApi.Inputs;
using Xunit;

#endregion

namespace PatientNow.CleanArchTemplate.Tests.Integration.Controllers;

[Collection("Test 1")]
public class PatientControllerTests : IClassFixture<WebApiTestFactory>
{
    private readonly HttpClient _httpClient;
    private readonly WebApiTestFactory _webApiTestFactory;

    public PatientControllerTests(WebApiTestFactory webApiTestFactory)
    {
        _webApiTestFactory = webApiTestFactory;
        _httpClient = _webApiTestFactory.CreateClient();
    }

    [Fact(DisplayName = "Should return a http status code 200 and PatientDto.")]
    public async Task Get_ParameterWithPatientId_ReturnAStatusCode200AndPatientDto()
    {
        //Arrange
        var patientId = 1;
        var url = $"api/Patient/{patientId}";

        //Act
        var result = await _httpClient.GetAsync(url);

        //Assert
        result.Should().Be200Ok()
            .And.Satisfy<PatientDto>(model =>
            {
                model.FirstName.Should().Be("Patient");
                model.MiddleName.Should().Be("Test");
            });
    }

    [Fact(DisplayName = "Should return a bad request when to try register a new patient.")]
    public async Task Post_PatientInput_ReturnABadRequest()
    {
        //Arrange
        var url = "api/Patient";
        PatientInfoInput patientInput = new()
        {
            FirstName = "Maria",
            LastName = "Jose",
            Dob = DateTime.Parse("01/24/1980")
        };

        var content = new StringContent(JsonSerializer.Serialize(patientInput), Encoding.UTF8, "application/json");

        //Act
        var result = await _httpClient.PostAsync(url, content);
        var con = await result.Content.ReadAsStringAsync();

        //Assert
        result.Should().Be400BadRequest();
    }
}