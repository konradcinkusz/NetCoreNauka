using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore
{
    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    //{
    //    public DataContext CreateDbContext(string[] args)
    //    {
    //        var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json", optional: false)
    //            .AddJsonFile($"appsettings.{envName}.json")
    //            .Build();
    //        var builder = new DbContextOptionsBuilder<DataContext>();
    //        builder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
    //        return new DataContext(builder.Options);
    //    }
    //}
}
