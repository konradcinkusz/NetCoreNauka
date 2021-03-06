﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PartyInvites.Models;
using System;
using System.IO;

namespace Users
{

    public class DesignTimeDbContextFactoryIdentity : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json")
                .Build();
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
            return new DataContext(builder.Options);
        }
    }
}
