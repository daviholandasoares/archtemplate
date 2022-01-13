#region

using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PatientNow.CleanArchTemplate.Infrastructure.Data;
using PatientNow.CleanArchTemplate.Tests.Integration.Utilities.Seeds;

#endregion

namespace PatientNow.CleanArchTemplate.Tests.Integration.Fixtures;

public class WebApiTestFactory : WebApplicationFactory<WebApi.Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(x =>
                x.ServiceType == typeof(DbContextOptions<MyPatientNowContext>));

            if (descriptor != null)
                services.Remove(descriptor);


            services.AddDbContext<MyPatientNowContext>(options =>
            {
                options.UseInMemoryDatabase("mypatientnowtests");
            });

            var serviceProvider = services.BuildServiceProvider();

            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetService<MyPatientNowContext>();

            try
            {
                PatientBasicInfoSeed.SeedPatients(context)
                    .WaitAsync(TimeSpan.FromSeconds(10))
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        });
    }
}