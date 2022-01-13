#region
using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatientNow.CleanArchTemplate.Infrastructure.Data;
#endregion

namespace PatientNow.CleanArchTemplate.Tests.Integration.Fixtures;

public class DatabaseFixture : IDisposable
{
    private readonly IServiceProvider _serviceProvider = new ServiceCollection()
        .AddEntityFrameworkInMemoryDatabase()
        .BuildServiceProvider();

    public DatabaseFixture()
    {
        var options = CreateContextOptionsInMemory();
        Context = new MyPatientNowContext(options);

        //Context = new TestDbContext(options);
        //EnsureDatabase();
    }

    public MyPatientNowContext Context { get; init; }
 
    //internal TestDbContext Context;

    /// <summary>
    /// Ensure the creation of database in memory.
    /// </summary>
    protected DbContextOptions<MyPatientNowContext> CreateContextOptionsInMemory()
    {
        var builder = new DbContextOptionsBuilder<MyPatientNowContext>();
        builder.UseInMemoryDatabase("mypatientdbtests")
            .UseInternalServiceProvider(_serviceProvider);

        return builder.Options;
    }

    /// <summary>
    /// Ensure the creation of database in local file and using SqlLite.
    /// </summary>
    protected DbContextOptions<MyPatientNowContext> CreateContextOptionsUseLocalFile()
    {
        var storeType = "Filename=Test.db"; //"Filename=:memory:"; 
        var builder = new DbContextOptionsBuilder<MyPatientNowContext>();
        builder.UseSqlite(new SqliteConnection(storeType));

        return builder.Options;
    }

    /// <summary>
    /// Ensure the creation of database in hosted on server or docker.
    /// </summary>
    protected DbContextOptions<MyPatientNowContext> CreateContextOptionsHosted()
    {
        var builder = new DbContextOptionsBuilder<MyPatientNowContext>();
        builder.UseSqlServer("DATABASECONNECTIONSTRING");

        return builder.Options;
    }

    public void EnsureDatabase()
    {
        Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        // Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}