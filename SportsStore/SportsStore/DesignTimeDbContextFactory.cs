using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SportsStore.Models;
using System;
using System.IO;

namespace SportsStore
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
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: false)
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(configuration["Data:SportStoreProducts:ConnectionString"]);
            return new ApplicationDbContext(builder.Options);
        }
    }
}
