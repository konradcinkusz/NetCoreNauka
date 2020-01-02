using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using Users.Models;

namespace Users
{

    public class DesignTimeDbContextFactoryIdentity : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json")
                .Build();
            var builder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            builder.UseSqlServer(configuration["Data:SportStoreIdentity:ConnectionString"]);
            return new AppIdentityDbContext(builder.Options);
        }
    }
}
