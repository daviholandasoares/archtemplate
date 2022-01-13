#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PatientNow.CleanArchTemplate.Core.Models;
using PatientNow.CleanArchTemplate.Infrastructure.Data;

#endregion

namespace PatientNow.CleanArchTemplate.Tests.Integration.Utilities.Seeds;

internal static class PatientBasicInfoSeed
{
    public static async Task SeedPatients(MyPatientNowContext context)
    {
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();

        var patients = new List<PatientBasicInfo>
        {
            new()
            {
                PatientId = 1,
                Fname = "Patient",
                Mname = "Test",
                Refsourcedetail = "",
                Dob = DateTime.UtcNow
            },
            new()
            {
                PatientId = 2,
                Fname = "Patient",
                Lname = "Second",
                Mname = "Test",
                Refsourcedetail = "",
                Dob = DateTime.UtcNow
            }
        };

        await context.PatientBasicInfos.AddRangeAsync(patients);
        await context.SaveChangesAsync();
    }
}