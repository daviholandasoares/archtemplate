#region

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PatientNow.CleanArchTemplate.Core.Models;
using PatientNow.CleanArchTemplate.Infrastructure.Data;

#endregion

namespace PatientNow.CleanArchTemplate.Tests.Integration.Utilities;

internal class TestDbContext : MyPatientNowContext
{
    public TestDbContext(DbContextOptions<MyPatientNowContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PatientBasicInfo>().HasData(
            new List<PatientBasicInfo>
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
            });

        base.OnModelCreating(modelBuilder);
    }
}