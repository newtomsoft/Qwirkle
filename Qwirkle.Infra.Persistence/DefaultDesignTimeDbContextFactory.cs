﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Qwirkle.Infra.Persistence;
using System;
using System.IO;

namespace Data
{
    public class DefaultDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DefaultDbContext>
    {
        public DefaultDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DefaultDbContext> optionBuilder = new DbContextOptionsBuilder<DefaultDbContext>();
            string path = Directory.GetCurrentDirectory();
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            string persistence = Environment.GetEnvironmentVariable("PERSISTENCE") ?? "Sqlite";

            IConfigurationBuilder builder = new ConfigurationBuilder()
                               .SetBasePath(path)
                               .AddJsonFile($"appsettings.{env}.json");
            IConfigurationRoot config = builder.Build();
            string connectionString = config.GetConnectionString(persistence);
            Console.WriteLine($"ASPNETCORE_ENVIRONMENT is : {env}");
            Console.WriteLine($"PERSISTENCE is : {persistence} ; connectionString is : {connectionString}");
            if (persistence == "SqlServer")
                optionBuilder.UseSqlServer(connectionString);
            else
                optionBuilder.UseSqlite(connectionString);
            return new DefaultDbContext(optionBuilder.Options);
        }
    }
}